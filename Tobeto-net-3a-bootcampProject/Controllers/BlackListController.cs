using Business.Abstracts;
using Business.Concretes;
using Business.Requests.Applicant;
using Business.Requests.BlackList;
using Business.Requests.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tobeto_net_3a_bootcampProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlackListController : BaseController
{
    private readonly IBlackListService _blackListManager;

    public BlackListController(IBlackListService blackListManager)
    {
        _blackListManager = blackListManager;
    }

    [HttpPost("AddAsync")]
    public async Task<IActionResult> Add(CreateBlackListRequest request)
    {
        return HandleDataResult(await _blackListManager.AddAsync(request));
    }

    [HttpDelete("DeleteAsync")]
    public async Task<IActionResult> Delete(DeleteBlackListRequest request)
    {
        return HandleResult(await _blackListManager.DeleteAsync(request));
    }

    [HttpDelete("SoftDeleteAsync")]
    public async Task<IActionResult> SoftDelete(DeleteBlackListRequest request)
    {
        return HandleResult(await _blackListManager.SoftDeleteAsync(request));
    }

    [HttpPost("GetByIdAsync")]
    public async Task<IActionResult> GetById(int request)
    {
        var user = await _blackListManager.GetByIdAsync(request);
        return HandleDataResult(user);
    }

    [HttpPost("GetByApplicantIdAsync")]
    public async Task<IActionResult> GetByApplicantId(int request)
    {
        var user = await _blackListManager.GetByApplicantIdAsync(request);
        return HandleDataResult(user);
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _blackListManager.GetAllAsync();
        return HandleDataResult(users);
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> Update(UpdateBlackListRequest request)
    {
        return HandleDataResult(await _blackListManager.UpdateAsync(request));
    }
}
