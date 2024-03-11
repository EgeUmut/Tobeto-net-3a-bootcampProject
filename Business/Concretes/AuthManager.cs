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

    [CacheRemoveAspect("IInstructorService.Get")]
    public async Task<IDataResult<AccessToken>> RegisterInstructor(InstructorForRegisterDto registerDto)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(registerDto.Password, out passwordHash, out passwordSalt);
        var instructor = new Instructor
        {
            Email = registerDto.Email,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            CompanyName = registerDto.CompanyName,
            DateOfBirth = registerDto.DateOfBirth,
            NationalIdentity = registerDto.NationalIdentity,
            UserName = registerDto.UserName
        };
        await _ınstructorRepository.AddAsync(instructor);
        var createAccessToken = await CreateAccessToken(instructor);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }

    [CacheRemoveAspect("IEmployeetService.Get")]
    public async Task<IDataResult<AccessToken>> RegisterEmployee(EmployeeForRegisterDto registerDto)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(registerDto.Password, out passwordHash, out passwordSalt);
        var employee = new Employee
        {
            Email = registerDto.Email,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Position = registerDto.Position,
            DateOfBirth = registerDto.DateOfBirth,
            NationalIdentity = registerDto.NationalIdentity,
            UserName = registerDto.UserName
        };
        await _employeeRepository.AddAsync(employee);
        var createAccessToken = await CreateAccessToken(employee);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }

    [CacheRemoveAspect("IApplicantService.Get")]
    public async Task<IDataResult<AccessToken>> RegisterApplicant(ApplicantForRegisterDto registerDto)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(registerDto.Password, out passwordHash, out passwordSalt);
        var applicant = new Applicant
        {
            Email = registerDto.Email,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            About = registerDto.About,
            DateOfBirth = registerDto.DateOfBirth,
            NationalIdentity = registerDto.NationalIdentity,
            UserName = registerDto.UserName
        };
        await _applicantRepository.AddAsync(applicant);
        var createAccessToken = await CreateAccessToken(applicant);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
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
