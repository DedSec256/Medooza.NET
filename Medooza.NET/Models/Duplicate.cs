using System;
using System.Xml.Serialization;

namespace Medooza.NET.Models
{
	[Serializable]
	public class Duplicate
	{
		[XmlElement("fragment", typeof(Fragment))]
		public Fragment[] Fragments { get; set; }

		[XmlAttribute("cost")]
		public long Cost { get; set; }

		[XmlAttribute("hash")]
		public long Hash { get; set; }

		[XmlAttribute("exp")]
		public long Exp { get; set; }
	}
}
