namespace Articles.Abstractions.Enums;

public enum ContributionArea
{
	//mandatory
	OriginalDraft = 1,  // writing the first version
	Revision,           // improving the draft after feedback

	//optional
	Analysis,           // methods, formal analysis
	Investigation,      // experiments, data collection
	Visualization       // figures, charts
}
