namespace Articles.Abstractions.Enums;

public enum AssetType
{
    Manuscript = 1,        // Author’s original submission file

    SupplementaryFile = 10,// Additional supporting files (appendices, extra material)
    Figure = 11,           // Images, charts, diagrams linked to the article
    DataSheet = 12         // Raw data tables or datasets provided by the author
}
