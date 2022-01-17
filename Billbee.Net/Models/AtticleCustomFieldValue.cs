namespace Billbee.Net.Models
{
    public class AtticleCustomFieldValue
    {
        public long? ArticleId;

        public ArticleCustomFieldDefinition Definition;

        public long? DefinitionId;
        public long? Id;

        public object Value;
    }
}