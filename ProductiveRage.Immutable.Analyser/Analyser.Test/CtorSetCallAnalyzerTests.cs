﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace ProductiveRage.Immutable.Analyser.Test
{
	[TestClass]
	public class CtorSetCallAnalyzerTests : DiagnosticVerifier
	{
		[TestMethod]
		public void BlankContent()
		{
			VerifyCSharpDiagnostic("");
		}

		[TestMethod]
		public void LegacyIdealUsage()
		{
			var testContent = @"
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public class PersonDetails : IAmImmutable
					{
						public PersonDetails(int id, NameDetails name)
						{
							this.CtorSet(_ => _.Id, id);
							this.CtorSet(_ => _.Name, name);
						}
						public int Id { get; private set; }
						public NameDetails Name { get; private set; }
					}
				}";

			VerifyCSharpDiagnostic(testContent);
		}

		[TestMethod]
		public void IdealUsage()
		{
			var testContent = @"
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public class PersonDetails : IAmImmutable
					{
						public PersonDetails(int id, NameDetails name)
						{
							this.CtorSet(_ => _.Id, id);
							this.CtorSet(_ => _.Name, name);
						}
						public int Id { get; }
						public NameDetails Name { get; }
					}
				}";

			VerifyCSharpDiagnostic(testContent);
		}

		[TestMethod]
		public void TargetIsNotThis()
		{
			var testContent = @"
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public class Test
					{
						public void Go(PersonDetails p)
						{
							p.CtorSet(_ => _.Id, 123);
						}
					}

					public class PersonDetails : IAmImmutable
					{
						public PersonDetails(int id, string name)
						{
							this.CtorSet(_ => _.Id, id);
							this.CtorSet(_ => _.Name, name);
						}
						public int Id { get; private set; }
						public string Name { get; private set; }
					}
				}";

			var expected = new DiagnosticResult
			{
				Id = CtorSetCallAnalyzer.DiagnosticId,
				Message = CtorSetCallAnalyzer.SimpleMemberAccessRule.MessageFormat.ToString(),
				Severity = DiagnosticSeverity.Error,
				Locations = new[]
				{
					new DiagnosticResultLocation("Test0.cs", 10, 8)
				}
			};

			VerifyCSharpDiagnostic(testContent, expected);
		}

		[TestMethod]
		public void NotCalledFromWithinConstructor()
		{
			var testContent = @"
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public class PersonDetails : IAmImmutable
					{
						public PersonDetails(int id, string name)
						{
							this.CtorSet(_ => _.Id, id);
							this.CtorSet(_ => _.Name, name);
						}
						public int Id { get; private set; }
						public string Name { get; private set; }
						public void Rename(string name)
						{
							this.CtorSet(_ => _.Name, name);
						}
					}
				}";

			var expected = new DiagnosticResult
			{
				Id = CtorSetCallAnalyzer.DiagnosticId,
				Message = CtorSetCallAnalyzer.ConstructorRule.MessageFormat.ToString(),
				Severity = DiagnosticSeverity.Error,
				Locations = new[]
				{
					new DiagnosticResultLocation("Test0.cs", 17, 8)
				}
			};

			VerifyCSharpDiagnostic(testContent, expected);
		}

		[TestMethod]
		public void PropertyIdentifierReturnsVariableInsteadOfProperty()
		{
			var testContent = @"
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public class PersonDetails : IAmImmutable
					{
						public PersonDetails(int id, string name)
						{
							this.CtorSet(_ => id, id);
							this.CtorSet(_ => _.Name, name);
						}
						public int Id { get; private set; }
						public string Name { get; private set; }
					}
				}";

			var expected = new DiagnosticResult
			{
				Id = CtorSetCallAnalyzer.DiagnosticId,
				Message = CtorSetCallAnalyzer.SimplePropertyAccessorArgumentAccessRule.MessageFormat.ToString(),
				Severity = DiagnosticSeverity.Error,
				Locations = new[]
				{
					new DiagnosticResultLocation("Test0.cs", 10, 21)
				}
			};

			VerifyCSharpDiagnostic(testContent, expected);
		}

		[TestMethod]
		public void PropertyIdentifierReturnsMethodInsteadOfProperty()
		{
			var testContent = @"
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public class PersonDetails : IAmImmutable
					{
						public PersonDetails(int id, string name)
						{
							this.CtorSet(_ => _.Id, id);
							this.CtorSet(_ => _.ToString(), name);
						}
						public int Id { get; private set; }
						public string Name { get; private set; }
					}
				}";

			var expected = new DiagnosticResult
			{
				Id = CtorSetCallAnalyzer.DiagnosticId,
				Message = CtorSetCallAnalyzer.SimplePropertyAccessorArgumentAccessRule.MessageFormat.ToString(),
				Severity = DiagnosticSeverity.Error,
				Locations = new[]
				{
					new DiagnosticResultLocation("Test0.cs", 11, 21)
				}
			};

			VerifyCSharpDiagnostic(testContent, expected);
		}

		[TestMethod]
		public void PropertyIdentifierReturnsManipulatedInsteadOfSimpleProperty()
		{
			var testContent = @"
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public class PersonDetails : IAmImmutable
					{
						public PersonDetails(int id, string name)
						{
							this.CtorSet(_ => Id + 1, id);
							this.CtorSet(_ => _.Name, name);
						}
						public int Id { get; private set; }
						public string Name { get; private set; }
					}
				}";

			var expected = new DiagnosticResult
			{
				Id = CtorSetCallAnalyzer.DiagnosticId,
				Message = CtorSetCallAnalyzer.SimplePropertyAccessorArgumentAccessRule.MessageFormat.ToString(),
				Severity = DiagnosticSeverity.Error,
				Locations = new[]
				{
					new DiagnosticResultLocation("Test0.cs", 10, 21)
				}
			};

			VerifyCSharpDiagnostic(testContent, expected);
		}

		[TestMethod]
		public void PropertyWithGetterWithBridgeAttribute()
		{
			var testContent = @"
				using Bridge;
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public class PersonDetails : IAmImmutable
					{
						public PersonDetails(int id, string name)
						{
							this.CtorSet(_ => _.Id, id);
							this.CtorSet(_ => _.Name, name);
						}
						public int Id { [Name(""getSpecialId"")] get; private set; }
						public string Name { get; private set; }
					}
				}";

			var expected = new DiagnosticResult
			{
				Id = CtorSetCallAnalyzer.DiagnosticId,
				Message = CtorSetCallAnalyzer.BridgeAttributeAccessRule.MessageFormat.ToString(),
				Severity = DiagnosticSeverity.Error,
				Locations = new[]
				{
					new DiagnosticResultLocation("Test0.cs", 11, 21)
				}
			};

			VerifyCSharpDiagnostic(testContent, expected);
		}

		[TestMethod]
		public void PropertyWithSetterWithBridgeAttribute()
		{
			var testContent = @"
				using Bridge;
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public class PersonDetails : IAmImmutable
					{
						public PersonDetails(int id, string name)
						{
							this.CtorSet(_ => _.Id, id);
							this.CtorSet(_ => _.Name, name);
						}
						public int Id { get; [Name(""setSpecialId"")] private set; }
						public string Name { get; private set; }
					}
				}";

			var expected = new DiagnosticResult
			{
				Id = CtorSetCallAnalyzer.DiagnosticId,
				Message = CtorSetCallAnalyzer.BridgeAttributeAccessRule.MessageFormat.ToString(),
				Severity = DiagnosticSeverity.Error,
				Locations = new[]
				{
					new DiagnosticResultLocation("Test0.cs", 11, 21)
				}
			};

			VerifyCSharpDiagnostic(testContent, expected);
		}

		/// <summary>
		/// This test also exists in the WithCallAnalyzerTests class, where its purpose is documented in more detail
		/// </summary>
		[TestMethod]
		public void PropertyTargetMustNotBeManipulatedOrReCast()
		{
			var testContent = @"
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public interface IHaveAnId
					{
						int Id { get; set; }
					}

					public class Something : IAmImmutable, IHaveAnId
					{
						public Something(int id, string name)
						{
							this.CtorSet(_ => ((IHaveAnId)_).Id, id);
							this.CtorSet(_ => _.Name, name);
						}
						int IHaveAnId.Id { get; set; }
						public string Name { get; private set; }
					}
				}";

			var expected = new DiagnosticResult
			{
				Id = CtorSetCallAnalyzer.DiagnosticId,
				Message = CtorSetCallAnalyzer.IndirectTargetAccessorAccessRule.MessageFormat.ToString(),
				Severity = DiagnosticSeverity.Error,
				Locations = new[]
				{
					new DiagnosticResultLocation("Test0.cs", 15, 21)
				}
			};

			VerifyCSharpDiagnostic(testContent, expected);
		}


		/// <summary>
		/// This tests the fix for Issue 6, which showed that the TPropertyValue type parameter could be a type that was less specific that the property - which would mean
		/// that the With call would set the target property to a type that it shouldn't be possible for it to be (for example, it would allow a string property to be set
		/// to an instance of an object that wasn't a string).
		/// </summary>
		[TestMethod]
		public void TPropertyValueMayNotBeAncestorOfPropertyType()
		{
			var testContent = @"
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public class SomethingWithAnId : IAmImmutable
					{
						public SomethingWithAnId(string id)
						{
							this.CtorSet(_ => _.Id, new object());
						}
						public string Id { get; private set; }
					}
				}";

			var expected = new DiagnosticResult
			{
				Id = CtorSetCallAnalyzer.DiagnosticId,
				Message = string.Format(
					CtorSetCallAnalyzer.PropertyMayNotBeSetToInstanceOfLessSpecificTypeRule.MessageFormat.ToString(),
					"string",
					"Object"
				),
				Severity = DiagnosticSeverity.Error,
				Locations = new[]
				{
					new DiagnosticResultLocation("Test0.cs", 10, 8)
				}
			};

			VerifyCSharpDiagnostic(testContent, expected);
		}

		/// <summary>
		/// This is a companion to TPropertyValueMayNotBeAncestorOfPropertyType that illustrates that TPropertyValue does not have to be the precise same type as the
		/// target property - it may be a MORE specific type (but it may not be a LESS specific type)
		/// </summary>
		[TestMethod]
		public void TPropertyValueMayBeSpecialisationOfPropertyType()
		{
			var testContent = @"
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public class SomethingWithAnId : IAmImmutable
					{
						public SomethingWithAnId(string id)
						{
							this.CtorSet(_ => _.Id, id);
						}
						public object Id { get; private set; }
					}
				}";
			VerifyCSharpDiagnostic(testContent);
		}

		[TestMethod]
		public void ReadOnlyPropertiesMayBeSetByCtorSet()
		{
			var testContent = @"
				using ProductiveRage.Immutable;

				namespace TestCase
				{
					public class PersonDetails : IAmImmutable
					{
						public PersonDetails(int id, NameDetails name)
						{
							this.CtorSet(_ => _.Id, id);
							this.CtorSet(_ => _.Name, name);
						}
						[ReadOnly] public int Id { get; }
						public NameDetails Name { get; }
					}
				}";

			VerifyCSharpDiagnostic(testContent);
		}

		protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
		{
			return new CtorSetCallAnalyzer();
		}
	}
}