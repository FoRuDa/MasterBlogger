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
    public class CreateModel : PageModel
    {

        private readonly IArticleCategoryApplication articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(CreateArticleCategory command)
        {
            articleCategoryApplication.Create(command);
            return RedirectToPage("./index");
        }
    }
}
