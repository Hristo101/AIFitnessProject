using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService _commentService)
        {
            this.commentService = _commentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(string senderId,int trainerId, string content, int rating)
        {
            await commentService.AddNewComment( senderId,  trainerId,  content,  rating);

            return RedirectToAction("DetailsTrainerForUser", "Trainer", new {id=trainerId});
        }
        [HttpPost]
        public async Task<IActionResult> EditComment(int commentId,int trainerId, string content, int rating)
        {
            await commentService.EditComment(commentId, content, rating);

            return RedirectToAction("DetailsTrainerForUser", "Trainer", new { id = trainerId });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteComment(int commentId,int trainerId)
        {
            await commentService.DeleteComment(commentId);

            return RedirectToAction("DetailsTrainerForUser", "Trainer", new { id = trainerId });
        }
    }
}
