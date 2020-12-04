using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Common
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
        DateTime Created { get; set; }
    }
}
