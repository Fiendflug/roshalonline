﻿using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Interfaces
{
    public interface IDatabaseWorker : IDisposable
    {
        IRepository<News> News { get; }
        IRepository<Note> Notes { get; }
        IRepository<User> Users { get; }
        IRepository<Tarif> Tarifs { get; }
        IRepository<Product> Products { get; }
        IRepository<Feedback> Feedbacks { get; }

        void Save();
    }
}