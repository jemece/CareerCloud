﻿using System;
using System.Linq;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        { }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();
            string[] validTopLevelDomains = { ".ca", ".com", ".biz" };

            foreach (CompanyProfilePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyWebsite) || !validTopLevelDomains.Any(d => poco.CompanyWebsite.EndsWith(d)))
                    validationErrors.Add(new ValidationException(600, $"CompanyWebsite for CompanyProfile {poco.CompanyWebsite} must end with one of the following extensions – \".ca\", \".com\", \".biz\""));

                if (string.IsNullOrEmpty(poco.ContactPhone))
                {
                    validationErrors.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.ContactPhone} is is not in the required format"));
                }
                else
                {
                    string[] phoneComponents = poco.ContactPhone.Split('-');
                    if (phoneComponents.Length < 3)
                    {
                        validationErrors.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.ContactPhone} is not in the required format."));
                    }
                    else
                    {
                        if (phoneComponents[0].Length < 3)
                        {
                            validationErrors.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.ContactPhone} is not in the required format."));
                        }
                        else if (phoneComponents[1].Length < 3)
                        {
                            validationErrors.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.ContactPhone} is not in the required format."));
                        }
                        else if (phoneComponents[2].Length < 4)
                        {
                            validationErrors.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.ContactPhone} is not in the required format."));
                        }
                    }
                }
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}