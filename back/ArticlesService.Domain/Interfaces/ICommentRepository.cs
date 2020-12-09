using ArticlesService.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Interfaces
{
    public interface ICommentRepository
    {
        List<CommentDto> GetComments(int articleId);

        int GetCommentsCount(int articleId);
    }
}
