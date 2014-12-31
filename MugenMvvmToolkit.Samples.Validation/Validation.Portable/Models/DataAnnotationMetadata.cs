#if !PCL
using System;
using System.Collections.Generic;
using System.Linq;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;
using System.ComponentModel.DataAnnotations;
using Validation.Portable.Attributes;

namespace Validation.Portable.Models
{
    //NOTE: We can not use attributes for validation in the portable assembly because it does not support it. 
    //NOTE: But we can add link to this file and use it on specified platform that supports the attributes.
    public sealed class UserModelMetadata
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public sealed class ValidatableModelMetadata
    {
        [Required, StringLength(10, MinimumLength = 2)]
        public string Name { get; set; }

        [Required, StringLength(500, MinimumLength = 2), OptionalValidation]
        public string Description { get; set; }
    }


    public class MetadataModule : ModuleBase
    {
        #region Constructors

        public MetadataModule()
            : base(true, LoadMode.All)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        protected override bool LoadInternal()
        {
            var oldProvider = ServiceProvider.EntityMetadataTypeProvider;
            ServiceProvider.EntityMetadataTypeProvider = type => EntityMetadataTypeProvider(type, oldProvider);
            return true;
        }

        protected override void UnloadInternal()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the metadata types for the specified type.
        /// </summary>
        private static IEnumerable<Type> EntityMetadataTypeProvider(Type type, Func<Type, IEnumerable<Type>> oldProvider)
        {
            var types = new List<Type>();
            if (type == typeof(UserModel))
                types.Add(typeof(UserModelMetadata));
            else if (type == typeof(ValidatableModel))
                types.Add(typeof(ValidatableModelMetadata));
            if (oldProvider != null)
                types.AddRange(oldProvider(type) ?? Enumerable.Empty<Type>());
            return types;
        }

        #endregion
    }
}
#endif
