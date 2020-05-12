using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using Erc1.Forms;
using Erc1.DAL;



namespace Erc1.BAL
{
	public enum MissionType
	{
		Urgent,
		Cold,
		Fire,
		Activity
	}
	public enum FromTo
	{
		Hospital,
		Home
	}
    class AddMission
    {
		public AddMission()
		{

		}
		public المهمات_المنفذة Mission;

		private int centerID;
		private int carID;
		private int montlyID;
		private int annualID;
		private DateTime date;
		private MissionType missionType;
		private int missionTypeID;
		private string[] caseName;
		private int[] caseNameID;
		private int caseTypeID;
		private string caseTypeName;
		private string moreInfoAboutCase;
		private PatientInfo patientInfo;
		private ParamedicsInfo paramedicsInfo;



		public int CenterID
		{
			get { return centerID; }
			set { centerID = value; }
		}
		public int CarID
		{
			get { return carID; }
			set { carID = value; }


		}
		public int MonthlyID
		{
			get { return montlyID; }
			set { montlyID = value; }
		}
		public int AnnualID
		{
			get { return annualID; }
			set { annualID = value; }
		}
		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}
		public MissionType MissionType
		{
			get { return missionType; }
			set { missionType = value; }
		}
		public int MissionTypeID
		{
			get { return missionTypeID; }
			set { missionTypeID = value; }
		}
		public string[] CaseName
		{
			get { return caseName; }
			set { caseName = value; }
		}
		public int[] CaseNameID
		{
			get { return caseNameID; }
			set { caseNameID = value; }
		}
		public int CaseTypeID
		{
			get { return caseTypeID; }
			set { caseTypeID = value; }
		}
		public string CaseTypeName
		{
			get { return caseTypeName; }
			set { caseTypeName = value; }
		}
		public string MoreInfoAboutCase
		{
			get { return moreInfoAboutCase; }
			set { moreInfoAboutCase = value; }
		}
		public PatientInfo PatientInfo 
		{
			get {return patientInfo; }
			set { patientInfo = value; }
		}
		public ParamedicsInfo ParamedicsInfo
		{
			get { return paramedicsInfo; }
			set { paramedicsInfo = value; }
		}

		


		public المهمات_المنفذة SaveImplementedMission()
		{
			Mission = new المهمات_المنفذة();
			Mission.الرمز_الشهري = MonthlyID;
			//Mission.رمز_السنوي = AnnualID; change datatype of annualid
			Mission.الآلية = carID;
			Mission.التاريخ = Date;
			Mission.طبيعة_المهمة = MissionTypeID;
			//dabbousi should creat a casestable that is have as a key(monthlyid,annualid)
			//dabbousi should creat a caseTypetable 
			Mission.التفاصيل = MoreInfoAboutCase;
			PatientInfo.SaveInfo(Mission);
			ParamedicsInfo.SaveInfo(Mission);

			return Mission;



		}



	}
	class PatientInfo
	{
		public PatientInfo()
		{

		}

		private int patientID;
		private string patientName;
		private bool canSit;
		private FromTo from;
		private FromTo to;

		private int fromhospitalID;
		private string fromhospitalName;
		private int fromdepatementID ;
		private string fromdepartementName;
		private int fromhosfloor;
		private int fromroom;

		private int tohospitalID;
		private string tohospitalName;
		private int todepatementID;
		private string todepartementName;
		private int tohosfloor;
		private int toroom;

		private int fromcityID;
		private string fromcityName;
		private string fromregionName;
		private int fromregionID;
		private string fromstreetName;
		private string frombuilding;
		private int fromfloor;
		private string frommoreInfoAboutAdress;

		private int tocityID;
		private string tocityName;
		private string toregionName;
		private int toregionID;
		private string tostreetName;
		private string tobuilding;
		private int tofloor;
		private string tomoreInfoAboutAdress;

		private string medicineName;
		private string[] infectiousdiseases;
		private int medicineID;
		private int[] infectiousdiseasesID;
		private int insuranceID;
		private string insuranceName;
		private string moreInfoAboutPatient;
		private string causeOfCancilling;

		public string CauseOfCancilling 
		{
			get {return causeOfCancilling; }
			set { causeOfCancilling = value; } 
		}
		public string MoreInfoAboutPatient
		{
			get { return moreInfoAboutPatient; }
			set { moreInfoAboutPatient = value; }
		}
		public string InsuranceName
		{
			get { return insuranceName; }
			set { insuranceName = value; }
		}
		public int InsuranceID
		{
			get { return insuranceID; }
			set { insuranceID = value; }
		}
		public int[] InfectiousdiseasesID
		{
			get { return infectiousdiseasesID; }
			set { infectiousdiseasesID = value; }
		}
		public int MedicineID
		{
			get { return medicineID; }
			set { medicineID = value; }
		}
		public string[] Infectiousdiseases
		{
			get { return infectiousdiseases; }
			set { infectiousdiseases = value; }
		}
		public string MedicineName
		{
			get { return medicineName; }
			set { medicineName = value; }
		}
		public string ToMoreInfoAboutAdress
		{
			get { return tomoreInfoAboutAdress; }
			set { tomoreInfoAboutAdress = value; }
		}
		public int Tofloor
		{
			get { return tofloor; }
			set { tofloor = value; }
		}
		public string Tobuilding
		{
			get { return tobuilding; }
			set { tobuilding = value; }
		}
		public string TostreetName
		{
			get { return tostreetName; }
			set { tostreetName = value; }
		}
		public int ToregionID
		{
			get { return toregionID; }
			set { toregionID = value; }
		}
		public string ToregionName
		{
			get { return toregionName; }
			set { toregionName = value; }
		}
		public string ToCityName
		{
			get { return tocityName; }
			set { tocityName = value; }
		}
		public int ToCityID
		{
			get { return tocityID; }
			set { tocityID = value; }
		}

		public string FromMoreInfoAboutAdress
		{
			get { return frommoreInfoAboutAdress; }
			set { frommoreInfoAboutAdress = value; }
		}
		public int Fromfloor
		{
			get { return fromfloor; }
			set { fromfloor = value; }
		}
		public string Frombuilding
		{
			get { return frombuilding; }
			set { frombuilding = value; }
		}
		public string FromstreetName
		{
			get { return fromstreetName; }
			set { fromstreetName = value; }
		}
		public int FromregionID
		{
			get { return fromregionID; }
			set { fromregionID = value; }
		}
		public string FromregionName
		{
			get { return fromregionName; }
			set { fromregionName = value; }
		}
		public string FromCityName
		{
			get { return fromcityName; }
			set { fromcityName = value; }
		}
		public int FromCityID
		{
			get { return fromcityID; }
			set { fromcityID = value; }
		}

		public int ToRoom
		{
			get { return toroom; }
			set { toroom = value; }
		}
		public int ToHosFloor
		{
			get { return tohosfloor; }
			set { tohosfloor = value; }
		}
		public string ToDepartementName
		{
			get { return todepartementName; }
			set { todepartementName = value; }
		}
		public int ToDepatementID
		{
			get { return todepatementID; }
			set { todepatementID = value; }
		}
		public string ToHospitalName
		{
			get { return tohospitalName; }
			set { tohospitalName = value; }
		}
		public int ToHospitalID
		{
			get { return tohospitalID; }
			set { tohospitalID = value; }
		}

		public int FromRoom
		{
			get { return fromroom; }
			set { fromroom = value; }
		}
		public int FromHosFloor
		{
			get { return fromhosfloor; }
			set { fromhosfloor = value; }
		}
		public string FromDepartementName
		{
			get { return fromdepartementName; }
			set { fromdepartementName = value; }
		}
		public int FromDepatementID 
		{
			get { return fromdepatementID; }
			set { fromdepatementID = value; }
		}
		public string FromHospitalName
		{
			get { return fromhospitalName; }
			set { fromhospitalName = value; }
		}
		public int FromHospitalID
		{
			get { return fromhospitalID; }
			set { fromhospitalID = value; }
		}

		public FromTo To
		{
			get { return to; }
			set { to = value; }
		}
		public FromTo From
		{
			get { return from; }
			set { from = value; }
		}
		public bool CanSit
		{
			get { return canSit; }
			set { canSit = value; }
		}
		public string PatientName
		{
			get { return patientName; }
			set { patientName = value; }
		}
		public int PatientID 
		{
			get { return patientID; }
			set { patientID = value; }
		}

		public static bool IsPatientExist(int PatientID)
		{
			return false;
		}
		public bool SaveInfo(المهمات_المنفذة Mission)
		{
			Mission.المريض = patientID;
			
			if(!IsPatientExist(patientID))
			{
				المرضى Patient = new المرضى();
				//get data of new patient and added him to data table of patients
				//a new form appear and the user fill the data 
				//addpatient class
			}
			if (From == FromTo.Home)
			{
				Mission.من_رمز_المدينة = FromCityID;
				Mission.من_رمز_المنطقة = FromregionID;
				Mission.تفاصيل_ال_من = FromstreetName + " ," + Frombuilding + " ," + Fromfloor + " ," + FromMoreInfoAboutAdress;
			}
			else
			{
				Mission.من_مشفى = FromHospitalID;
				Mission.من_القسم = FromDepatementID;
				Mission.تفاصيل_ال_من = FromHosFloor + " ," + fromroom;
			}

			if (To == FromTo.Home)
			{
				Mission.الى_رمز_المدينة = ToCityID;
				Mission.الى_رمز_المنطقة = ToregionID;
				Mission.تفاصيل_ال_الى = TostreetName + " ," + Tobuilding + " ," + Tofloor + " ," + ToMoreInfoAboutAdress;
			}
			else
			{
				Mission.إلى_مشفى = ToHospitalID;
				Mission.إلى_القسم = ToDepatementID;
				Mission.تفاصيل_ال_الى = ToHosFloor + " ," + ToRoom;
			}
			// add infectious case variable to implemented mission
			// add canSit variable to implemented mission
			// call function to add new infectious case for patient if it is not exist

			return true;
		}
		

	}
	class ParamedicsInfo
	{
		private int driverID;
		private string driverName;
		private int headOfShiftID;
		private string headOfShiftName;
		private int headOfMissionID;
		private string headOfMissionName;
		private int paramedic1ID;
		private string paramedic1Name;
		private int paramedic2ID;
		private string paramedic2Name;
		private int recipientMissionID;
		private string recipientMissionName;
		private string moreInfo;
		private string callerName;
		private string callerPhone;

		public string CallerPhone
		{
			get { return callerPhone; }
			set { callerPhone = value; }
		}

		public string CallerName
		{
			get { return callerName; }
			set { callerName = value; }
		}

		public string MoreInfo
		{
			get { return moreInfo; }
			set { moreInfo = value; }
		}
		public string RecipientMissionName
		{
			get { return recipientMissionName; }
			set { recipientMissionName = value; }
		}
		public int RecipientMissionID
		{
			get { return recipientMissionID; }
			set { recipientMissionID = value; }
		}
		public string Paramedic2Name
		{
			get { return paramedic2Name; }
			set { paramedic2Name = value; }
		}
		public int Paramedic2ID
		{
			get { return paramedic2ID; }
			set { paramedic2ID = value; }
		}
		public string Paramedic1Name
		{
			get { return paramedic1Name; }
			set { paramedic1Name = value; }
		}
		public int Paramedic1ID
		{
			get { return paramedic1ID; }
			set { paramedic1ID = value; }
		}
		public string HeadOfMissionName
		{
			get { return headOfMissionName; }
			set { headOfMissionName = value; }
		}
		public int HeadOfMissionID
		{
			get { return headOfMissionID; }
			set { headOfMissionID = value; }
		}
		public string HeadOfShiftName
		{
			get { return headOfShiftName; }
			set { headOfShiftName = value; }
		}
		public int HeadOfShiftID
		{
			get { return headOfShiftID; }
			set { headOfShiftID = value; }
		}
		public string DriverName
		{
			get { return driverName; }
			set { driverName = value; }
		}
		public int DriverID
		{
			get { return driverID; }
			set { driverID = value; }
		}
		public bool SaveInfo(المهمات_المنفذة Mission)
		{
			Mission.السائق = DriverID;
			Mission.مسؤول_المهمة = HeadOfMissionID;
			Mission.مسعف_1 = Paramedic1ID;
			Mission.مسعف_2 = Paramedic2ID;
			Mission.متلقي_المهمة = RecipientMissionID;
			//add caller name and phone to database
			//add headofshift to database in mission table

			return false;
		}
	}
	
}
