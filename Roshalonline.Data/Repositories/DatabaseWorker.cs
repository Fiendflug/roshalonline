using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roshalonline.Data.Repositories;
using Roshalonline.Data.Interfaces;
using Roshalonline.Data.Context;
using Roshalonline.Data.Models;

namespace Roshalonline.Data.Repositories
{
    public class DatabaseWorker : IDatabaseWorker
    {
        private NewsRepository _newsRepository;
        private NoteRepository _noteRepository;
        private UserRepository _userRepository;
        private TarifRepository _tarifRepository;
        private ProductRepository _productRepository;
        private FeedbackRepository _feedbackRepository;

        private DatabaseContext _database;

        public bool _disposed;

        public DatabaseWorker()
        {
            _database = new DatabaseContext();
            _disposed = false;
        }

        public IRepository<Feedback> Feedbacks
        {
            get
            {
                if (_feedbackRepository == null)
                {
                    _feedbackRepository = new FeedbackRepository(_database);
                }
                return _feedbackRepository;
            }
        }

        public IRepository<News> News
        {
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new NewsRepository(_database);
                }
                return _newsRepository;
            }
        }

        public IRepository<Note> Notes
        {
            get
            {
                if (_noteRepository == null)
                {
                    _noteRepository = new NoteRepository(_database);
                }
                return _noteRepository;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_database);
                }
                return _productRepository;
            }
        }

        public IRepository<Tarif> Tarifs
        {
            get
            {
                if (_tarifRepository == null)
                {
                    _tarifRepository = new TarifRepository(_database);
                }
                return _tarifRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_database);
                }
                return _userRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _database.Dispose();
                }
                _disposed = true;
            }
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _database.SaveChanges();
        }
    }
}
