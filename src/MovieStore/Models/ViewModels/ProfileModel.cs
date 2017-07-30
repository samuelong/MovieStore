using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieStore.Models;
using System.Collections;

namespace MovieStore.Models.ViewModels
{
    public class ProfileModel : IEnumerable<ProfileModel>
    {
        public string Name { get; set; }
        public List<Rental> Rentals { get; set; }

        public IEnumerator<ProfileModel> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
