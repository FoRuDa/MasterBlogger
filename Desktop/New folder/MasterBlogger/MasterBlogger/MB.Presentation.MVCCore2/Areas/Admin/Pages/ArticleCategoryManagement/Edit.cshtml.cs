using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Aplication.contracts;
using DB.Aplication.contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore2.Areas.Admin.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        [BindProperty] public RenameArticleCategory ArticleCategory { set; get; }

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            ArticleCategory = _articleCategoryApplication.Get(id);
        }
        public RedirectToPageResult OnPost()
        {
            _articleCategoryApplication.Rename(ArticleCategory);
            return RedirectToPage("/articlecategorymanagement/index");
        }
    }
}
