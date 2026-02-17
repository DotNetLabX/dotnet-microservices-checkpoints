using System.ComponentModel;

namespace Articles.Abstractions.Enums;

public enum UserRoleType
{
	// Cross-domain: 1–9
	[Description("Editorial Office Admin")]
	EOF = 1,

	// Submission: 11–19
	[Description("Author")]
	AUT = 11,
	[Description("Corresponding Author")]
	CORAUT = 12,

    // Review: 21–29
    [Description("Review Editor")]
    REVED = 21,

    // Auth-only: 91–99
    [Description("User Admin")]
    USERADMIN = 91
}


