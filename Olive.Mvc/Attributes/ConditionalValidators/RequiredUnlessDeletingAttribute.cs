﻿namespace Olive.Mvc
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RequiredUnlessDeletingAttribute : RequiredAttribute
    {
        readonly string DeletingProperty;

        /// <summary>
        /// Check if the object is going to be deleted skip the validation.
        /// </summary>
        /// <param name="deletingProperty">The boolean property`s name which shows the object will be deleted.</param>
        public RequiredUnlessDeletingAttribute(string deletingProperty = "MustBeDeleted") =>
            DeletingProperty = deletingProperty;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ConditionalValidatorsHelper.ValidateIfFalse(base.IsValid, value, validationContext, DeletingProperty);
        }
    }
}