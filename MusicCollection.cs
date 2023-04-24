using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    [Serializable]
    public class MusicComposition
    {
        private string title;
        private string artist;
        private string album;
        private string genre;
        private double duration;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        public string Album
        {
            get { return album; }
            set { album = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public double Duration
        {
            get { return duration; }
            set
            {
                if (value < 1.30)
                {
                    throw new ArgumentException("Duration can not be less then 1:30 minutes");
                }
                duration = value;
            }
        }

        public MusicComposition() {}

        public MusicComposition(string title, string artist, string album, string genre, double duration)
        {
            this.title = title;
            this.artist = artist;
            this.album = album;
            this.genre = genre;
            this.duration = duration;
        }

        public override string ToString()
        {
            return $"MusicComposition [Title: {title}, Artist: {artist}, Album: {album}, Genre: {genre}, Duration: {duration}]";
        }
    }

    [Serializable]
    public class MusicCompositionList : IList<MusicComposition>
    {
        private List<MusicComposition> CompositionList = new List<MusicComposition>();

        public int Count
        {
            get { return CompositionList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public MusicComposition this[int index]
        {
            get { return CompositionList[index]; }
            set { CompositionList[index] = value; }
        }

        public void FillComposition()
        {
            CompositionList.Add(new MusicComposition("Zombie", "The Cranberries", "No Need to Argue", "Grunge", 5.06));
            CompositionList.Add(new MusicComposition("Gangsta's Paradise", "Coolio", "Gangsta's Paradise", "Gangsta rap", 4.03));
            CompositionList.Add(new MusicComposition("The Way You Make Me Feel", "Michael Jackson & Britney Spears", "Bad", "Funk", 4.26));
            CompositionList.Add(new MusicComposition("Smooth Criminal", "Michael Jackson", "Bad", "Pop", 4.17));
            CompositionList.Add(new MusicComposition("Are You Ready", "AC/DC", "The Razors Edge", "Hard rock", 4.10));
            CompositionList.Add(new MusicComposition("Believer", "Imagine Dragons", "Evolve", "Pop rock", 3.23));
            CompositionList.Add(new MusicComposition("It's My Life", "Bon Jovi", "Crush", "Pop rock", 3.45));
            CompositionList.Add(new MusicComposition("Kawaki Wo Ameku", "Minami", "カワキヲアメク", "Jpop", 4.13));
            CompositionList.Add(new MusicComposition("I don't wanna be you any more", "Billie Eilish", "Don't Smile at Me", "Pop", 3.24));
            CompositionList.Add(new MusicComposition("La Isla Bonita", "Alizée", "Psychédélices", "Latin pop", 4.02));
        }

        public List<MusicComposition> GetBy(Func<MusicComposition, bool> suitableComposition)
        {
            return CompositionList.Where(suitableComposition).ToList();
        }

        public void WriteToFile(IFormatter formatter, string pathToFile)
        {
            using (FileStream fileStream = new FileStream(pathToFile, FileMode.Create))
            {
                formatter.Serialize(fileStream, this);
            }
        }

        public void ReadFromFile(IFormatter formatter, string pathToFile)
        {
            using (FileStream fileStream = new FileStream(pathToFile, FileMode.Open))
            {
                foreach (MusicComposition o in formatter.Deserialize(fileStream) as MusicCompositionList)
                {
                    CompositionList.Add(o);
                }
            }
        }

        public int IndexOf(MusicComposition item)
        {
            return CompositionList.IndexOf(item);
        }

        public void Insert(int index, MusicComposition item)
        {
            CompositionList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            CompositionList.RemoveAt(index);
        }

        public void Add(MusicComposition item)
        {
            CompositionList.Add(item);
        }

        public void Clear()
        {
            CompositionList.Clear();
        }

        public bool Contains(MusicComposition item)
        {
            return CompositionList.Contains(item);
        }

        public void CopyTo(MusicComposition[] array, int arrayIndex)
        {
            CompositionList.CopyTo(array, arrayIndex);
        }

        public bool Remove(MusicComposition item)
        {
            return CompositionList.Remove(item);
        }

        public IEnumerator<MusicComposition> GetEnumerator()
        {
            return CompositionList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return CompositionList.GetEnumerator();
        }

        public void Sort(Comparison<MusicComposition> comparator)
        {
            CompositionList.Sort(comparator);
        }
    }
}
