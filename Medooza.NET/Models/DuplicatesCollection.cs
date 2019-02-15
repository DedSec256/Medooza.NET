using System;
using System.Xml.Serialization;

namespace Medooza.NET.Models
{
	[Serializable]
	[XmlRoot("root")]
	public class DuplicatesCollection
	{
		[XmlElement("duplicate", typeof(Duplicate))]
		public Duplicate[] Duplicates { get; set; }
	}
}
