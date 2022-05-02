using MyFirstWebApp.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.ViewModels
{
    public class SortViewModel
    {
        public SortState DateSort { get; private set; }
        public SortState LikesSort { get; private set; }
        public SortState CurrentState { get; private set; }
        public SortViewModel(SortState sortState)
        {
            DateSort = sortState == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;
            LikesSort = sortState == SortState.LikesAsc ? SortState.LikesDesc : SortState.LikesAsc;
            CurrentState = sortState;
        }
    }
}
