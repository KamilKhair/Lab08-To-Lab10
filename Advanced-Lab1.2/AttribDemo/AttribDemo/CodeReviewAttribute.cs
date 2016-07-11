using System;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class CodeReviewAttribute : Attribute
    {
        public CodeReviewAttribute(string reviewerName, string reviewTime, bool isApproved)
        {
            ReviewerName = reviewerName;
            ReviewTime = reviewTime;
            IsApproved = isApproved;
        }

        public string ReviewerName { get; set; }
        public string ReviewTime { get; set; }
        public bool IsApproved { get; set; }
    }
}
