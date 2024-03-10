using Business.Abstracts;
using Business.Dtos.Register;
using Core.Aspects.Autofac.Caching;
using Core.Exceptios.Types;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IInstructorRepository _ınstructorRepository;
    private readonly IUserRepository _userRepository;
    private readonly IApplicantRepository _applicantRepository;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository,
        IEmployeeRepository employeeRepository, IInstructorRepository ınstructorRepository, IUserRepository userRepository, IApplicantRepository applicantRepository)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _userOperationClaimRepository = userOperationClaimRepository;
        _employeeRepository = employeeRepository;
        _ınstructorRepository = ınstructorRepository;
        _userRepository = userRepository;
        _applicantRepository = applicantRepository;
    }

    public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
        .AsNoTracking().Where(x => x.UserId == user.Id).Select(x => new OperationClaim
        {
            Id = x.OperationClaimId,
            Name = x.OperationClaim.Name
        }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken, "Created Token");
    }

    public async Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto)
    {
        var user = await _userService.GetByMailAsync(userForLoginDto.Email);
        await UserShouldBeExists(user.Data);
        await UserEmailShouldBeExists(userForLoginDto.Email);
        await UserPasswordShouldBeMatch(user.Data.Id, userForLoginDto.Password);
        var createAccessToken = await CreateAccessToken(user.Data);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Login Success");
    }
    [CacheRemoveAspect("IApplicantService.Get")]
    [CacheRemoveAspect("IEmployeetService.Get")]
    [CacheRemoveAspect("IInstructorService.Get")]
    public async Task<IDataResult<AccessToken>> Register(UserForRegisterDto registerDto)
    {
        await UserEmailShouldBeNotExists(registerDto.Email);

        if (registerDto is EmployeeForRegisterDto && registerDto != null)
        {
            var employeeDto = registerDto as EmployeeForRegisterDto;

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(employeeDto.Password, out passwordHash, out passwordSalt);
            var employee = new Employee
            {
                Email = employeeDto.Email,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Position = employeeDto.Position,
                DateOfBirth = employeeDto.DateOfBirth,
                NationalIdentity = employeeDto.NationalIdentity,
                UserName = employeeDto.UserName
            };
            await _employeeRepository.AddAsync(employee);
            var createAccessToken = await CreateAccessToken(employee);
            return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
        }
        else if (registerDto is InstructorForRegisterDto && registerDto != null)
        {
            var instructorDto = registerDto as InstructorForRegisterDto;

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(instructorDto.Password, out passwordHash, out passwordSalt);
            var instructor = new Instructor
            {
                Email = instructorDto.Email,
                FirstName = instructorDto.FirstName,
                LastName = instructorDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CompanyName = instructorDto.CompanyName,
                DateOfBirth = instructorDto.DateOfBirth,
                NationalIdentity = instructorDto.NationalIdentity,
                UserName = instructorDto.UserName
            };
            await _ınstructorRepository.AddAsync(instructor);
            var createAccessToken = await CreateAccessToken(instructor);
            return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
        }
        else if (registerDto is ApplicantForRegisterDto && registerDto != null)
        {
            var applicantDto = registerDto as ApplicantForRegisterDto;

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(applicantDto.Password, out passwordHash, out passwordSalt);
            var applicant = new Applicant
            {
                Email = applicantDto.Email,
                FirstName = applicantDto.FirstName,
                LastName = applicantDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                About = applicantDto.About,
                DateOfBirth = applicantDto.DateOfBirth,
                NationalIdentity = applicantDto.NationalIdentity,
                UserName = applicantDto.UserName
            };
            await _applicantRepository.AddAsync(applicant);
            var createAccessToken = await CreateAccessToken(applicant);
            return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
        }
        else
        {
            return new ErrorDataResult<AccessToken>("Invalid type");
        }
    }

    private async Task UserEmailShouldBeNotExists(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user is not null) throw new BusinessException("User mail already exists");
    }

    private async Task UserEmailShouldBeExists(string email)
    {
        var user = await _userService.GetByMailAsync(email);
        if (user.Data is null) throw new BusinessException("Email or Password don't match");
    }

    private Task UserShouldBeExists(User? user)
    {
        if (user is null) throw new BusinessException("Email or Password don't match");
        return Task.CompletedTask;
    }

    private async Task UserPasswordShouldBeMatch(int id, string password)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException("Email or Password don't match");
    }
}
