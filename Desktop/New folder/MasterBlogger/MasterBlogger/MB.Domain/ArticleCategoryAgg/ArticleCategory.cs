using System;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get;private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get;private set; }
        public DateTime Created { get;private set; }

        public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
        {
            NullException(title);
            validatorService.CheckThatRecordExist(title);
            Title = title;
            IsDeleted = false;
            Created = DateTime.Now;
        }

        public void NullException(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }

        public void Rename(string title)
        {
            NullException(title);
            Title = title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }
        public void Active()
        {
            IsDeleted = false;
        }
    }

    class ArticleCategoryImpl : ArticleCategory
    {
    }
}
