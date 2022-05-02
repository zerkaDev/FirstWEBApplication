using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.ViewModels.Enums
{
    public enum SortState
    {
        DateAsc, // по возрастанию даты создания
        DateDesc, // по убыванию даты создания
        LikesAsc, // по количество добавленных в избранное по возрастанию
        LikesDesc // по количество добавленных в избранное по убываию
    }
}
