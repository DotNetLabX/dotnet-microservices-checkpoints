using System.ComponentModel;

namespace Articles.Abstractions.Enums;

public enum UserRoleType : int
{
		// Cross-domain: 1–9
		[Description("Editorial Office Admin")]
		EOF = 1,

		// Submission: 11–19
		[Description("Author")]
		AUT = 11,
		[Description("Corresponding Author")]
		CORAUT = 12,
}
