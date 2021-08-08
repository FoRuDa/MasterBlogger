using System;
using System.Collections.Generic;
using DB.Aplication.contracts.ArticleCategory;

namespace DB.Aplication.contracts
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void Create(CreateArticleCategory command);
        void Rename(RenameArticleCategory command);
        RenameArticleCategory Get(long id);
        void Remove(long id);
        void Active(long id);
    }
}
