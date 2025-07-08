﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Domain.Entities;

namespace GameNest.Application.Interfaces
{
    public interface IJwtProvider
    {
        public string GenerateToken(Account account);
    }
}
