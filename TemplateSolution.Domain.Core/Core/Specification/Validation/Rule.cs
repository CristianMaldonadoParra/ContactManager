﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateSolution.Domain.Core.Core.Specification.Validation
{
    public class Rule<T>
    {
        private readonly Specification<T> _specificationSpec;

        public Rule(Specification<T> spec, string errorMessage)
        {
            _specificationSpec = spec;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public bool Validate(T obj)
        {
            return _specificationSpec.IsSatisfiedBy(obj);
        }
    }
}
