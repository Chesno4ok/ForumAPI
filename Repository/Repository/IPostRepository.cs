﻿using Forum.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Logic.Repository
{
    public interface IPostRepository<T> : IRepository<T> where T : Post
    {
    }
}
