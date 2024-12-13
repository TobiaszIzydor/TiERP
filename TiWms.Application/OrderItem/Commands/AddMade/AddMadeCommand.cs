﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiWms.Application.OrderItem.Commands.AddMade
{
    public class AddMadeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public AddMadeCommand(int id)
        {
            Id = id;
        }
    }
}