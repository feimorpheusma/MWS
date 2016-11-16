using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace DispApp.Generated.rpid
{
	[GeneratedCode("xsd", "2.0.50727.3038"), XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:rpid", IncludeInSchema = false)]
	[System.Serializable]
	public enum ItemChoiceType3
	{
		[XmlEnum("##any:")]
		Item,
		aircraft,
		airport,
		arena,
		automobile,
		bank,
		bar,
		bus,
		[XmlEnum("bus-station")]
		busstation,
		cafe,
		classroom,
		club,
		construction,
		[XmlEnum("convention-center")]
		conventioncenter,
		cycle,
		government,
		hospital,
		hotel,
		industrial,
		library,
		office,
		other,
		outdoors,
		parking,
		[XmlEnum("place-of-worship")]
		placeofworship,
		prison,
		@public,
		[XmlEnum("public-transport")]
		publictransport,
		residence,
		restaurant,
		school,
		[XmlEnum("shopping-area")]
		shoppingarea,
		stadium,
		store,
		street,
		theater,
		train,
		[XmlEnum("train-station")]
		trainstation,
		truck,
		underway,
		unknown,
		warehouse,
		water,
		watercraft
	}
}
