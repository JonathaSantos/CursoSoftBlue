﻿using Agenda.Domain;
using Agenda.DAL;
using AutoFixture;
using Moq;
using System;

namespace Agenda.Repos.Test
{
    public class IContatoConstr : BaseConstr<IContato>
    {

        protected IContatoConstr():base()    
        {
            
        }

        public static IContatoConstr Um()
        {
            return new IContatoConstr();
        }

        public IContatoConstr ComNome(string nome)
        {
            _mock.SetupGet(o => o.Nome).Returns(nome);
            return this;
        }
        public IContatoConstr ComNumeroID(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id);
            return this;
        }
    }
}