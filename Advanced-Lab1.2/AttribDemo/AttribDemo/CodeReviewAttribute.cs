using System;

namespace AttribDemo
{
    /**
    Unless specified, the AttributeUsage attribute disallows decorating the same target more than once
    It was a requirement that multiple attribute instances would be allowed to decorate a single target
    Consider :
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class CodeReviewAttribute : Attribute
    {
        public CodeReviewAttribute(string reviewerName, string reviewTime, bool isApproved)
        {
            ReviewerName = reviewerName;
            ReviewTime = reviewTime;
            IsApproved = isApproved;
        }

        public string ReviewerName { get;}
        public string ReviewTime { get;}
        public bool IsApproved { get;}
    }
}
