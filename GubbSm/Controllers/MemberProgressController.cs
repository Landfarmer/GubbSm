using Umbraco.Cms.Core.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

public class MemberProgressController : UmbracoApiController
{
    private readonly IContentService _contentService;

    public MemberProgressController(IContentService contentService)
    {
        _contentService = contentService;
    }

    public IActionResult UpdateStatus(int userId, int challengeId, bool completed)
    {
        var userChallengeStatus = _contentService.GetById(challengeId);

        if (userChallengeStatus == null)
        {
            return NotFound();
        }

        userChallengeStatus.SetValue("completed", completed);
        _contentService.SaveAndPublish(userChallengeStatus);

        return Ok();
    }
}