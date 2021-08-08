using System;
using System.Collections.Generic;
using System.Globalization;
using DB.Aplication.contracts;
using DB.Aplication.contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;


        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)

        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }



        public void Active(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Active();
            _articleCategoryRepository.Save();
        }

        public void Create(CreateArticleCategory command)
        {
            var articlecategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);
            _articleCategoryRepository.Create(articlecategory);
        }

        public RenameArticleCategory Get(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategory 
            { 
            Id = articleCategory.Id,
            Title = articleCategory.Title
            
            
            };
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();

            var result = new List<ArticleCategoryViewModel>();

            foreach(var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    Creation = articleCategory.Created.ToString(CultureInfo.InvariantCulture),
                    IsDeleted = articleCategory.IsDeleted

                }) ;
                
            }
            return result;

        }

        public void Remove(long id)
        {
            var articlecategory = _articleCategoryRepository.Get(id);
            articlecategory.Remove();
            _articleCategoryRepository.Save();
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title);
            _articleCategoryRepository.Save();
        }
    }
}
