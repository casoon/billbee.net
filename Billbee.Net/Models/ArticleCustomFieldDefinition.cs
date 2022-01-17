namespace Billbee.Net.Models
{
    public enum ApiArticleCustomFieldType
    {
        TextField,
        Textarea,
        NumberInput,
        SelectInput
    }

    public class ArticleCustomFieldDefinition
    {
        public object Configuration;
        public long? Id;

        public bool IsNullable;

        public string Name;

        public ApiArticleCustomFieldType? Type;
    }
}