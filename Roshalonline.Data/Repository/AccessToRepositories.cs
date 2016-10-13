using Roshalonline.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Repository
{
    public class AccessToRepositories : IDisposable
    {
        private ModelsContext _workModelsContext;
        private NewsRepository _newsRepository;
        private NotesRepository _notesRepository;
        private PhoneBookRepository _phonebookRepository;
        private ProductsRepository _productsRepository;
        private TarifsRepository _tarifsRepository;

        private NewsCategoriesRepository _newsCategoryRepository;
        private TarifsCategoriesRepository _tarifCategoryRepository;
        private PhonebookCategoriesRepository _phonebookCategoryRepository;
        private ProductCategoriesRepository _productCategoryRepository;

        private bool _disposed;

        public NewsRepository NewsRepository
        {
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new NewsRepository(_workModelsContext);
                }
                return _newsRepository;
            }
        }
        public NotesRepository NotesRepository
        {
            get
            {
                if (_notesRepository == null)
                {
                    _notesRepository = new NotesRepository(_workModelsContext);
                }
                return _notesRepository;
            }
        }
        public PhoneBookRepository PhonebookRepository
        {
            get
            {
                if (_phonebookRepository == null)
                {
                    _phonebookRepository = new PhoneBookRepository(_workModelsContext);
                }
                return _phonebookRepository;
            }
        }
        public ProductsRepository ProductRepository
        {
            get
            {
                if (_productsRepository == null)
                {
                    _productsRepository = new ProductsRepository(_workModelsContext);
                }
                return _productsRepository;
            }
        }
        public TarifsRepository TarifsRepository
        {
            get
            {
                if (_tarifsRepository == null)
                {
                    _tarifsRepository = new TarifsRepository(_workModelsContext);
                }
                return _tarifsRepository;
            }
        }

        public NewsCategoriesRepository NewsCategoriesRepository
        {
            get
            {
                if (_newsCategoryRepository == null)
                {
                    _newsCategoryRepository = new NewsCategoriesRepository(_workModelsContext);
                }
                return _newsCategoryRepository;
            }
        }
        public TarifsCategoriesRepository TarifsCategoriesRepository
        {
            get
            {
                if (_tarifCategoryRepository == null)
                {
                    _tarifCategoryRepository = new TarifsCategoriesRepository(_workModelsContext);
                }
                return _tarifCategoryRepository;
            }
        }
        public PhonebookCategoriesRepository PhonebookCategoriesRepository
        {
            get
            {
                if (_phonebookCategoryRepository == null)
                {
                    _phonebookCategoryRepository = new PhonebookCategoriesRepository(_workModelsContext);
                }
                return _phonebookCategoryRepository;
            }
        }
        public ProductCategoriesRepository ProductCategoriesRepository
        {
            get
            {
                if (_productCategoryRepository == null)
                {
                    _productCategoryRepository = new ProductCategoriesRepository(_workModelsContext);
                }
                return _productCategoryRepository;
            }
        }

        public AccessToRepositories()
        {
            _workModelsContext = new ModelsContext();
            _disposed = false;
        }

        public void Save()
        {
            _workModelsContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _workModelsContext.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
