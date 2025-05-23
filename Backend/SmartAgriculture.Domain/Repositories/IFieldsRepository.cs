﻿using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Domain.Repositories
{
    public interface IFieldsRepository
    {
        Task<int> Create(Field entity);
        Task Delete(Field entity);
    }
}
