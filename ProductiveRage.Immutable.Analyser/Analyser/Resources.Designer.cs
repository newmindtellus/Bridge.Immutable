﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductiveRage.Immutable.Analyser {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ProductiveRage.Immutable.Analyser.Resources", typeof(Resources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CtorSet should only be used in specific circumstances.
        /// </summary>
        internal static string CtorAnalyserTitle {
            get {
                return ResourceManager.GetString("CtorAnalyserTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CtorSet&apos;s propertyRetriever lambda must directly indicate an instance property that has no Bridge attributes on the getter or setter.
        /// </summary>
        internal static string CtorBridgeAttributeMessageFormat {
            get {
                return ResourceManager.GetString("CtorBridgeAttributeMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CtorSet&apos;s propertyRetriever lambda must directly indicate an instance property with a getter and a setter (which may be private) or that is a readonly auto-property.
        /// </summary>
        internal static string CtorDirectPropertyTargetAccessorArgumentMessageFormat {
            get {
                return ResourceManager.GetString("CtorDirectPropertyTargetAccessorArgumentMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CtorSet should only be called within a constructor.
        /// </summary>
        internal static string CtorMayOnlyBeCalledWithConstructorMessageFormat {
            get {
                return ResourceManager.GetString("CtorMayOnlyBeCalledWithConstructorMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CtorSet must be a simple member access expression that targets &quot;this&quot; - it must be of the form this.CtorSet(..).
        /// </summary>
        internal static string CtorSimpleMemberAccessRuleMessageFormat {
            get {
                return ResourceManager.GetString("CtorSimpleMemberAccessRuleMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CtorSet&apos;s propertyRetriever lambda must directly indicate an instance property with a getter and a setter (which may be private) or that is a readonly auto-property.
        /// </summary>
        internal static string CtorSimplePropertyAccessorArgumentMessageFormat {
            get {
                return ResourceManager.GetString("CtorSimplePropertyAccessorArgumentMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GetProperty should only be used in a particular manner.
        /// </summary>
        internal static string GetPropertyAnalyserTitle {
            get {
                return ResourceManager.GetString("GetPropertyAnalyserTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GetProperty&apos;s propertyRetriever lambda must directly indicate an instance property that has no Bridge attributes on the getter or setter.
        /// </summary>
        internal static string GetPropertyBridgeAttributeMessageFormat {
            get {
                return ResourceManager.GetString("GetPropertyBridgeAttributeMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GetProperty&apos;s propertyRetriever lambda&apos;s target must be a direct access and may not include any casts or other indirection.
        /// </summary>
        internal static string GetPropertyDirectPropertyTargetAccessorArgumentMessageFormat {
            get {
                return ResourceManager.GetString("GetPropertyDirectPropertyTargetAccessorArgumentMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GetProperty&apos;s propertyRetriever lambda must directly indicate an instance property with a getter and a setter (which may be private) or that is a readonly auto-property.
        /// </summary>
        internal static string GetPropertySimplePropertyAccessorArgumentMessageFormat {
            get {
                return ResourceManager.GetString("GetPropertySimplePropertyAccessorArgumentMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Properties on IAmImmutable must follow prescribed guidelines.
        /// </summary>
        internal static string IAmImmutableAnalyserTitle {
            get {
                return ResourceManager.GetString("IAmImmutableAnalyserTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IAmImmutable implementation &apos;{0}&apos; has an empty constructor that may be used to populate the class.
        /// </summary>
        internal static string IAmImmutableAutoPopulatorAnalyserMessageFormat {
            get {
                return ResourceManager.GetString("IAmImmutableAutoPopulatorAnalyserMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IAmImmutable implementation may be auto-generated.
        /// </summary>
        internal static string IAmImmutableAutoPopulatorAnalyserTitle {
            get {
                return ResourceManager.GetString("IAmImmutableAutoPopulatorAnalyserTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IAmImmutable implementations may not have non-readonly public fields (such as {0}).
        /// </summary>
        internal static string IAmImmutableFieldsMayNotBePublicAndMutableMessageFormat {
            get {
                return ResourceManager.GetString("IAmImmutableFieldsMayNotBePublicAndMutableMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The setter on property &apos;{0}&apos; must be private as it is on a class that implements IAmImmutable.
        /// </summary>
        internal static string IAmImmutablePropertiesMayNotHavePublicSetterMessageFormat {
            get {
                return ResourceManager.GetString("IAmImmutablePropertiesMayNotHavePublicSetterMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property &apos;{0}&apos; must have a setter since it has a getter and is on a class that implements IAmImmutable.
        /// </summary>
        internal static string IAmImmutablePropertiesMustHaveSettersMessageFormat {
            get {
                return ResourceManager.GetString("IAmImmutablePropertiesMustHaveSettersMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to May not have Bridge attributes on properties with getters ({0}) on classes that implement IAmImmutable.
        /// </summary>
        internal static string IAmImmutablePropertiesMustNotHaveBridgeAttributesMessageFormat {
            get {
                return ResourceManager.GetString("IAmImmutablePropertiesMustNotHaveBridgeAttributesMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When new IAmImmutable instances are created via &quot;With&quot; calls, the constructor is not called and so any validation there will be bypassed. If parameter validation is required then you may add a &quot;Validate&quot; method to the class and call it at the end of the constructor, it will also be called whenever &quot;With&quot;creates a new instance. The &quot;Validate&quot; method must have no parameters and must not be decorated with any Bridge attributes (it is acceptable for the method to be private)..
        /// </summary>
        internal static string IAmImmutableValidationShouldNotBePerformedInConstructor {
            get {
                return ResourceManager.GetString("IAmImmutableValidationShouldNotBePerformedInConstructor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to With should only be used in a particular manner.
        /// </summary>
        internal static string WithAnalyserTitle {
            get {
                return ResourceManager.GetString("WithAnalyserTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to With&apos;s propertyRetriever lambda must directly indicate an instance property that has no Bridge attributes on the getter or setter.
        /// </summary>
        internal static string WithBridgeAttributeMessageFormat {
            get {
                return ResourceManager.GetString("WithBridgeAttributeMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to With&apos;s propertyRetriever lambda&apos;s target must be a direct access and may not include any casts or other indirection.
        /// </summary>
        internal static string WithDirectPropertyTargetAccessorArgumentMessageFormat {
            get {
                return ResourceManager.GetString("WithDirectPropertyTargetAccessorArgumentMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to With&apos;s propertyRetriever lambda must directly indicate an instance property with a getter and a setter (which may be private) or that is a readonly auto-property.
        /// </summary>
        internal static string WithSimplePropertyAccessorArgumentMessageFormat {
            get {
                return ResourceManager.GetString("WithSimplePropertyAccessorArgumentMessageFormat", resourceCulture);
            }
        }
    }
}
