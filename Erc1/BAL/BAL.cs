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

using System.Collections;
using System.Security.Permissions;
using System.Threading;
using System.Reflection;
using Erc1.CONTROLS;
using Erc1.Classes;
using System.Runtime.CompilerServices;
using Erc1.Forms._8_AddPatient;
using Google.Apis.Sheets.v4;
using Google.Apis.Auth.OAuth2;
using System.IO;
using Google.Apis.Services;
using Google.Apis.Sheets.v4.Data;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource.UpdateRequest;

namespace Erc1.BAL
{

	public enum MissionType
	{
		
		Cold,
		Urgent
	}
	public enum FromTo
	{
		Hospital,
		Home
	}

	public static class MyFunction
	{
		public static bool FillComboBox(ComboBox combo,object DataSource,string DisplayMember,string ValueMember)
		{
			try
			{


				
				combo.DataSource = DataSource;
				combo.DisplayMember = DisplayMember;
				combo.ValueMember = ValueMember;
				combo.SelectedItem = null;
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}


		}
	}

    class addMission
    {
		public addMission()
		{

		}
		
		public المهمات_المنفذة Mission;
		public المهماة_المؤجلة DMission;
		public المهمات_الملغاة CMission;


		private int centerID;
		private int carID;
		private int montlyID;
		private int annualID;
		private DateTime date;
		private MissionType missionType;
		private int missionTypeID;
		private DataTable cases;
		private int caseTypeID;
		private string caseTypeName;
		private string moreInfoAboutCase;
		private PatientInfo patientInfo;
		private ParamedicsInfo paramedicsInfo;
		private Erc1.Forms.MissionType missionty;


		public Erc1.Forms.MissionType MissionTy
		{
			get { return missionty; }
			set { missionty = value; }
		}
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
			set
			{
				missionType = value; 
				if(missionType==MissionType.Urgent)
				{
					MissionTypeID = 1;
				}
				else if(missionType==MissionType.Cold)
				{
					MissionTypeID = 2;
				}
			}
		}
		public int MissionTypeID
		{
			get 
			{ 
				return missionTypeID; 
			}
			set
			{
				missionTypeID = value;
			}
		}
		public DataTable Case
		{
			get
			{
				return cases;
			}
			set
			{
				cases = value;
			}
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

		
		

		public bool SaveImplementedMission()
		{
			Mission = new المهمات_المنفذة();
			Mission.رمز__المركز = centerID;
			Mission.الرمز_الشهري = MonthlyID;
			Mission.رمز_السنوي = AnnualID;
			Mission.الآلية = carID;
			Mission.التاريخ = Date;
			Mission.نوعية_الحالة = CaseTypeID;
			Mission.السنة = Date.Year;
			Mission.طبيعة_المهمة = MissionTypeID;
			Mission.التفاصيل = MoreInfoAboutCase;

			PatientInfo.SaveInfo(Mission);
			ParamedicsInfo.SaveInfo(Mission);
			
			DataTable cas = new DataTable();
			cas.Clear();
			cas.Columns.Add("رمز_الحالة");
			cas.Columns.Add("الرمز_الشهري");
			cas.Columns.Add("رمز_السنوي");
			cas.Columns.Add("السنة");


			DataRow dr;
			foreach (DataRow row in Case.Rows)
			{
				dr = cas.NewRow();
				dr["رمز_الحالة"] = row["ID"];
				dr["الرمز_الشهري"] = MonthlyID;
				dr["رمز_السنوي"] = AnnualID;
				dr["السنة"] = Date.Year;
				cas.Rows.Add(dr);
			}

			return mission.add_Mission(Mission) && mission.add_Cases(cas);



		}
		public bool SaveDelayedMission()
		{
			DMission = new المهماة_المؤجلة();
			DMission.رمز_المركز = centerID;
			//car
			//mission type
			DMission.رمز = MonthlyID;
			DMission.التاريخ_والوقت = Date;
			//case type
			//case
			// تفاصيل الحالة
			//patient id
			//patient name
			//can sit
			//from
			//to
			//caller  phone
			//caller name






			PatientInfo.SaveInfo(DMission);

			DataTable cas = new DataTable();
			cas.Clear();
			cas.Columns.Add("رمز_الحالة");
			cas.Columns.Add("الرمز_الشهري");
			cas.Columns.Add("رمز_السنوي");
			cas.Columns.Add("السنة");


			DataRow dr;
			foreach (DataRow row in Case.Rows)
			{
				dr = cas.NewRow();
				dr["رمز_الحالة"] = row["ID"];
				dr["الرمز_الشهري"] = MonthlyID;
				dr["رمز_السنوي"] = AnnualID;
				dr["السنة"] = Date.Year;
				cas.Rows.Add(dr);
			}


			return mission.add_Mission(DMission);



		}
		public bool SaveCanceledMission()
		{
			CMission = new المهمات_الملغاة();
			Mission.رمز__المركز = centerID;
			Mission.الرمز_الشهري = MonthlyID;
			Mission.رمز_السنوي = AnnualID;
			Mission.الآلية = carID;
			Mission.التاريخ = Date;
			// cases and casetype
			Mission.طبيعة_المهمة = MissionTypeID;
			Mission.التفاصيل = MoreInfoAboutCase;

			PatientInfo.SaveInfo(CMission);

			return mission.add_Mission(CMission);



		}


		public bool ImportInfo(AddMission addMission)
		{

			try
			{

				MissionTy = addMission.MissionTy;
				try
				{
					CenterID = int.Parse(addMission.CenterID.SelectedValue.ToString());
				}
				catch(Exception ex)
				{
					MessageBox.Show("Please choose one of the centers");
					return false;
				}

				try
				{
					CarID = int.Parse(addMission.CarId.Text.ToString());
					
				}
				catch (Exception ex)
				{
					MessageBox.Show("Please choose one of the car");
					return false;
				}
				
				MonthlyID = int.Parse(addMission.MonthlyID.Text);
				AnnualID = int.Parse(addMission.AnnualID.Text);


				DateTime Date = new DateTime(int.Parse(addMission.Year.Text), int.Parse(addMission.Month.Text), int.Parse(addMission.Day.Text), addMission.Time.Value.Hour, addMission.Time.Value.Minute, 0);
				this.Date = Date;
				MissionType = addMission.Type;

				
				if(addMission.cM == null || addMission.cM.SelectedCases.Rows.Count==0)
				{
					MessageBox.Show("Please choose Cases");
					return false;
				}
				else
				{
					Case = addMission.cM.SelectedCases;
				}
				try
				{
					CaseTypeID = int.Parse(addMission.CaseType.SelectedValue.ToString());

				}
				catch (Exception ex)
				{
					MessageBox.Show("Please choose case type");
					return false;
				}
				
				CaseTypeName = addMission.CaseType.Text;

				MoreInfoAboutCase = addMission.MoreInfoAboutCase.Text;

				bool PatientImporDone, ParamDone;



				if(MissionTy==Forms.MissionType.Implemented)
				{
					PatientInfo = new PatientInfo();
					ParamedicsInfo = new ParamedicsInfo();
					PatientImporDone = PatientInfo.ImportInfo(addMission.paI);
					ParamDone = ParamedicsInfo.ImportData(addMission.pI);
					return PatientImporDone && ParamDone;
				}
				else if(MissionTy == Forms.MissionType.Dlayed)
				{
					PatientInfo = new PatientInfo();
					PatientImporDone = PatientInfo.ImportInfo(addMission.paI);
				}
				else
				{
					PatientInfo = new PatientInfo();
					PatientImporDone = PatientInfo.ImportInfo(addMission.paI);
				}

				return true;
				
			}
			catch(Exception ex)
			{
				MessageBox.Show("يرجى تعبئة كافة المعلومات");
				return false;
			}
		



		}


		public static IEnumerable Get_Cases()
		{
			return mission.Get_الحالات();
		}
		public static IEnumerable Get_centers()
		{
			return mission.Get_Centers();
		}
		public static IEnumerable Get_CasesType()
		{
			return mission.Get_نوعيات_الحالات(); 
		}
		public static IEnumerable GetCars(int CentrID)
		{
			return mission.Getالآليات_by_المركز(CentrID);
		}
		public static IEnumerable GetCases()
		{
			return mission.Get_الحالات();
		}
		public static int GetMonthlyID(int year,int month)
		{
			return mission.Get_MonthlyID(year, month);
		}
		public static int GetAnuualID(int year)
		{
			return mission.Get_YearID(year);
		}
		





		static Thread ImportCasesType, ImportCenter, ImportCases, ImportMonthlyID, ImportAnnualId;
		static IEnumerable casetype = null, centers = null, Cases = null;

		public static bool FillAddMissionForm(AddMission addm)
		{
			try
			{
				int MonthlyId = 0, annualid = 0;
				ImportCasesType = new Thread(() => { casetype = addMission.Get_CasesType(); });
				ImportCenter = new Thread(() => { centers = addMission.Get_centers(); });
				ImportCases = new Thread(() => { Cases = addMission.GetCases(); });

				if (addm.MissionTy == Forms.MissionType.Implemented)
				{
					ImportMonthlyID = new Thread(() => { MonthlyId = GetMonthlyID(DateTime.Now.Year, DateTime.Now.Month); });
					ImportAnnualId = new Thread(() => { annualid = GetAnuualID(DateTime.Now.Year); });
					ImportMonthlyID.Start();
					ImportAnnualId.Start();
					ImportMonthlyID.Join();
					ImportAnnualId.Join();
					addm.MonthlyID.Text = MonthlyId.ToString();
					addm.AnnualID.Text = annualid.ToString();
				}
				else if(addm.MissionTy == Forms.MissionType.Dlayed)
				{

				}
				else if(addm.MissionTy == Forms.MissionType.Canceled)
				{

				}


				ImportCasesType.Start();
				ImportCenter.Start();
				ImportCases.Start();
				

				ImportCasesType.Join();
				ImportCenter.Join();
				ImportCases.Join();
				



				MyFunction.FillComboBox(addm.CenterID, centers, "centers", "id");
				addm.CenterID.SelectedValueChanged += addm.CenterID_SelectedValueChanged;


				MyFunction.FillComboBox(addm.CaseType, casetype, "النوعية", "الرمز");
	

				MyFunction.FillComboBox(addm.Case, Cases, "المرض", "رمز");

				




				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
		
		
		}


	}
	class PatientInfo
	{
		public PatientInfo()
		{

		}


        #region VARIABLES
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
		private string infectiousdiseases;
		private int medicineID;
		private int infectiousdiseasesID;
		private int insuranceID;
		private string insuranceName;
		private string moreInfoAboutPatient;
		private string causeOfCancilling;
		private int weight;

        #endregion

        #region proprties

		public int Weight
		{
			get { return weight; }
			set { weight = value; }
		}
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
		public int InfectiousdiseasesID
		{
			get { return infectiousdiseasesID; }
			set { infectiousdiseasesID = value; }
		}
		public int MedicineID
		{
			get { return medicineID; }
			set { medicineID = value; }
		}
		public string Infectiousdiseases
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

		#endregion


		public static bool IsPatientExist(int PatientID)
		{
			return false;
		}


        #region SAVEDATA
        public bool SaveInfo(المهمات_المنفذة Mission)
		{
			Mission.المريض = patientID;
			
			if(!IsPatientExist(patientID))
			{
				المرضى Patient = new المرضى();

				
			}

			من fom = new من();
			if (From == FromTo.Home)
			{
				
				int exist =-1;
				// exist=function return id of region if exist or -1 if not

				Mission.من = exist;
				

				
				Mission.تفاصيل_ال_من = FromstreetName + " ," + Frombuilding + " ," + Fromfloor + " ," + FromMoreInfoAboutAdress;
			}
			else if (From == FromTo.Hospital)
			{

				

				//bit = 1
				//Mission.من_مشفى = FromHospitalID;
				//Mission.من_القسم = FromDepatementID;

				int exist = -1;


				Mission.من = exist;




				Mission.تفاصيل_ال_من = FromHosFloor + " ," + fromroom;
			}

			if (To == FromTo.Home)
			{

				//Mission.الى_رمز_المدينة = ToCityID;
				//Mission.الى_رمز_المنطقة = ToregionID;
				Mission.تفاصيل_ال_الى = TostreetName + " ," + Tobuilding + " ," + Tofloor + " ," + ToMoreInfoAboutAdress;
			}
			else if (To == FromTo.Hospital)
			{
				//Mission.إلى_مشفى = ToHospitalID;
				//Mission.إلى_القسم = ToDepatementID;
				Mission.تفاصيل_ال_الى = ToHosFloor + " ," + ToRoom;
			}
			else
			{
				Mission.تفاصيل_ال_الى = ToMoreInfoAboutAdress;
			}

			Mission.مريض_مقعد = CanSit;
			if (MedicineID != -1)
			{
				Mission.الطبيب_المعالج = MedicineID;
			}
			else
			{
				Mission.الطبيب_المعالج = null;
			}

			if (InfectiousdiseasesID != -1)
			{
				Mission.الأمراض_المعدية = InfectiousdiseasesID;
			}
			else
			{
				Mission.الأمراض_المعدية = null;
			}






			return true;
		}

		public bool SaveInfo(المهمات_الملغاة Mission)
		{
			/*Mission.رمز_المريض = patientID;

			if (!IsPatientExist(patientID))
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
			}
			else
			{
				Mission.من_مشفى = FromHospitalID;
				Mission.من_القسم = FromDepatementID;
			}
			if (To == FromTo.Home)
			{
				Mission.الى_رمز_المدينة = ToCityID;
				Mission.الى_رمز_المنطقة = ToregionID;
			}
			else
			{
				Mission.إلى_مشفى = ToHospitalID;
				Mission.إلى_القسم = ToDepatementID;
			}
			*/



			return true;
		}

		public bool SaveInfo(المهماة_المؤجلة Mission)
		{
			/*= patientID;

			if (!IsPatientExist(patientID))
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
			}
			else
			{
				Mission.من_مشفى = FromHospitalID;
				Mission.من_القسم = FromDepatementID;
			}
			if (To == FromTo.Home)
			{
				Mission.الى_رمز_المدينة = ToCityID;
				Mission.الى_رمز_المنطقة = ToregionID;
			}
			else
			{
				Mission.إلى_مشفى = ToHospitalID;
				Mission.إلى_القسم = ToDepatementID;
			}

			*/


			return true;
		}



        #endregion




        public bool ImportInfo(CONTROLS.PatientInformation patientInfo)
		{
			try
			{
				try
				{
					PatientID = int.Parse(patientInfo.Name_Patient.SelectedValue.ToString());
				}
				catch(Exception ex)
				{
					MessageBox.Show("choose one patient");
				}

				PatientName = patientInfo.Name_Patient.Text;

				CanSit = patientInfo.CanSit.Check;

				if(patientInfo.FromHos.Check)
				{	

					From = FromTo.Hospital;

					try
					{
						FromHospitalID = int.Parse(patientInfo.Name_FromHospital.SelectedValue.ToString());
					}
					catch(Exception ex)
					{
						MessageBox.Show("Choose hospital");
						return false;
					}

					FromHospitalName = patientInfo.Name_FromHospital.Text;

					try
					{
						FromDepatementID = int.Parse(patientInfo.FromHosDepartement.SelectedValue.ToString());

					}
					catch (Exception ex)
					{
						MessageBox.Show("Choose hospital");
						return false;
					}

					
					FromDepartementName = patientInfo.FromHosDepartement.Text.ToString();

					try
					{
						FromHosFloor = int.Parse(patientInfo.FromHosFloor.SelectedItem.ToString());

						FromRoom = int.Parse(patientInfo.FromHosRoom.Text);
					}
					catch(Exception ex)
					{ }


				}
				else if(patientInfo.FromHome.Check)
				{
					From = FromTo.Home;

					try
					{
						FromCityID = int.Parse(patientInfo.FromCity.SelectedValue.ToString());
					}
					catch(Exception ex)
					{
						MessageBox.Show("Choose City");
						return false;
					}
					
					FromCityName = patientInfo.FromCity.Text.ToString();


					try
					{
						FromregionID = int.Parse(patientInfo.FromRegion.SelectedValue.ToString());
					}
					catch (Exception ex)
					{
						MessageBox.Show("Choose Region");
						return false;
					}
					

					FromregionName = patientInfo.FromRegion.Text.ToString();

					FromstreetName = patientInfo.FromStreet.Text;

					Frombuilding = patientInfo.FromBuilding.Text;
					try
					{
						Fromfloor = int.Parse(patientInfo.FromFloor.Text);
					}
					catch(Exception  ex)
					{
						
					}
					FromMoreInfoAboutAdress = patientInfo.MoreFromInfo.Text;


				}
				else
				{
					MessageBox.Show("يجب تعبئ كامل المعلومات");
				}

				if (patientInfo.ToHos.Check)
				{

					To = FromTo.Hospital;

					try
					{
						ToHospitalID = int.Parse(patientInfo.Name_ToHospital.SelectedValue.ToString());
					}
					catch (Exception ex)
					{
						MessageBox.Show("Choose hospital");
						return false;
					}

					ToHospitalName = patientInfo.Name_ToHospital.Text;

					try
					{
						ToDepatementID = int.Parse(patientInfo.ToHosDepartement.SelectedValue.ToString());

					}
					catch (Exception ex)
					{
						MessageBox.Show("Choose hospital");
						return false;
					}


					ToDepartementName = patientInfo.ToHosDepartement.Text.ToString();
					try
					{
						ToHosFloor = int.Parse(patientInfo.ToHosFloor.SelectedItem.ToString());

						ToRoom = int.Parse(patientInfo.ToHosRoom.Text);
					}
					catch(Exception ex)
					{
					}


				}
				else if (patientInfo.ToHome.Check)
				{
					To = FromTo.Home;
					try
					{
						ToCityID = int.Parse(patientInfo.ToCity.SelectedValue.ToString());
					}
					catch (Exception ex)
					{
						MessageBox.Show("Choose City");
						return false;
					}

					ToCityName = patientInfo.ToCity.Text.ToString();


					try
					{
						ToregionID = int.Parse(patientInfo.ToRegion.SelectedValue.ToString());
					}
					catch (Exception ex)
					{
						MessageBox.Show("Choose Region");
						return false;
					}


					ToregionName = patientInfo.ToRegion.Text.ToString();

					TostreetName = patientInfo.ToStreet.Text;

					Tobuilding = patientInfo.ToBuilding.Text;
					try
					{
						Tofloor = int.Parse(patientInfo.ToFloor.Text);
					}
					catch(Exception ex)
					{
					}
					ToMoreInfoAboutAdress = patientInfo.MoreToInfo.Text;


				}
				else
				{
					//MessageBox.Show("يجب تعبئ كامل المعلومات");
				}


				try
				{
					MedicineID = int.Parse(patientInfo.MedcineID.SelectedValue.ToString());
				}
				catch(Exception ex)
				{
					MedicineID = -1;
				}
				MedicineName = patientInfo.MedcineID.Text;
				try
				{
					InfectiousdiseasesID = int.Parse(patientInfo.InfectionDiseases.SelectedValue.ToString());
				}
				catch (Exception ex)
				{
					InfectiousdiseasesID =-1;
				}
				Infectiousdiseases = patientInfo.InfectionDiseases.Text;
				try
				{
					InsuranceID = int.Parse(patientInfo.Insurance.SelectedValue.ToString());
				}
				catch (Exception ex)
				{
					MessageBox.Show("f");
					InsuranceID = -1;
				}

				CauseOfCancilling = patientInfo.CancilingCause.Text;

				insuranceName = patientInfo.Insurance.Text;
				MoreInfoAboutPatient = patientInfo.OtherInfo.Text;
				


				return true;


			}
			catch (InvalidCastException ex)
			{
				MessageBox.Show("الرموز يجب أن تكون بالارقام");
				return false;
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}
		




		#region GETTEROFDATA
		public static IEnumerable GetPatients()
		{
			return mission.Get_المرضى();
		}
		public static IEnumerable GetHospitals()
		{
			return mission.Get_المستشفيات();
		}
		public static IEnumerable GetDepartementOfHos(int HosID)
		{
			return mission.Get_أقسام_المستشفيات(HosID);
		}
		public static short[] GetFloors(int HosID)
		{
			return mission.Get_طوابق_المستشفيات(HosID);
		}
		public static IEnumerable GetCities()
		{
			return mission.Get_المدن();
		}
		public static IEnumerable GetMedicine()
		{
			return mission.Get_الأطباء();
		}
		public static IEnumerable GetRegions(int CityID)
		{
			return mission.Get_المناطق(CityID);
		} 
		public static IEnumerable GetInsurance()
		{
			return mission.Get_الجهات_الضامنة();
		}
		public static IEnumerable GetInfectiousDeseases()
		{
			return mission.Get_الأمراض_المعدية();
		}

        #endregion

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
		private int callerPhone;


		public int CallerPhone
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

		public static IEnumerable GetWorkers()
		{
			return mission.Get_العاملون();
		}
		public static IEnumerable GetWorkers(int CenterID)
		{
			return mission.Get_العاملون_by_idالمراكز(CenterID);
		}
		public static IEnumerable GetDrivers(int CenterID)
		{
			return mission.Get_السائقون_by_idالمراكز(CenterID);
		}
		public static IEnumerable GetHeadOfMission(int CenterID)
		{
			return mission.Get_مسؤول_مهمة_by_idالمراكز(CenterID);
		}


		public bool SaveInfo(المهمات_المنفذة Mission)
		{
			try
			{
				
				
				
				

				

				if (Paramedic1ID != -1)
				{
					
				}
				else
				{
					
				}

				if (paramedic2ID != -1)
				{
					
				}
				else
				{
					
				}

				Mission.مسؤول_الدوام = HeadOfMissionID;

				if (RecipientMissionID != -1)
				{
					Mission.متلقي_المهمة = RecipientMissionID;
				}
				else

				{
					Mission.متلقي_المهمة = null;
				}
				
				if(CallerPhone!=-1)
				{
					Mission.رقم_المتصل = CallerPhone;
				}
				else
				{
					Mission.رقم_المتصل = null;
				}

				Mission.اسم_المتصل = CallerName;
				
				
				return true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
			
		}
		public bool ImportData(CONTROLS.ParamInformation paramInfo)
		{
			try
			{
				Paramedic1Name = paramInfo.Name_Paramedic1.Text;
				Paramedic2Name = paramInfo.Name_Paramedic2.Text;
				RecipientMissionName = paramInfo.Name_RecipientOfMission.Text;
				CallerName = paramInfo.CallerName.Text;
				try
				{

					Paramedic1ID = int.Parse(paramInfo.Name_Paramedic1.SelectedValue.ToString());
				}
				catch
				{
					Paramedic1ID = -1;
				}
				try
				{
					Paramedic2ID = int.Parse(paramInfo.Name_Paramedic2.SelectedValue.ToString());
				}
				catch
				{
					Paramedic2ID = -1;
				}
				try
				{
					RecipientMissionID = int.Parse(paramInfo.Name_RecipientOfMission.SelectedValue.ToString());
				}
				catch
				{
					RecipientMissionID = -1;
				}
				try
				{ 	
					
					CallerPhone = int.Parse(paramInfo.CallerPhone.Text);
				}
				catch(Exception ex)
				{
					
					
					
					CallerPhone = -1;

				}





				HeadOfMissionName = paramInfo.Name_HeadOfMission.Text;
				DriverName = paramInfo.Name_Driver.Text;
				HeadOfShiftName = paramInfo.Name_HeadOfShift.Text;

				try
				{
					HeadOfMissionID = int.Parse(paramInfo.Name_HeadOfMission.SelectedValue.ToString());
					HeadOfShiftID = int.Parse(paramInfo.Name_HeadOfShift.SelectedValue.ToString());
					DriverID = int.Parse(paramInfo.Name_Driver.SelectedValue.ToString());

				}
				catch(Exception ex)
				{
					MessageBox.Show("fill team information");
					return false;
				}


				MoreInfo = paramInfo.MoreInfo.Text;
				return true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}


		public static bool FillParamForm(Erc1.CONTROLS.ParamInformation pI,AddMission addm)
		{
			IEnumerable HeadOfshift = GetWorkers(int.Parse(addm.CenterID.SelectedValue.ToString()));
			IEnumerable HeadOfmission = GetHeadOfMission(int.Parse(addm.CenterID.SelectedValue.ToString()));
			IEnumerable paramedic1 = GetWorkers(int.Parse(addm.CenterID.SelectedValue.ToString()));
			IEnumerable paramedic2 = GetWorkers(int.Parse(addm.CenterID.SelectedValue.ToString()));
			IEnumerable Driver = GetDrivers(int.Parse(addm.CenterID.SelectedValue.ToString()));
			IEnumerable recipientOfMission = GetWorkers(int.Parse(addm.CenterID.SelectedValue.ToString()));

			string valuem = "الرمز", Display = "الاسم";

			try
			{
				pI.Name_HeadOfMission.SelectedValueChanged -= pI.Name_HeadOfMission_SelectedValueChanged;

				pI.Name_HeadOfShift.SelectedValueChanged -= pI.Name_HeadOfMission_SelectedValueChanged;

				pI.Name_Paramedic1.SelectedValueChanged -= pI.Name_HeadOfMission_SelectedValueChanged;

				pI.Name_Paramedic2.SelectedValueChanged -= pI.Name_HeadOfMission_SelectedValueChanged;

				pI.Name_RecipientOfMission.SelectedValueChanged -= pI.Name_HeadOfMission_SelectedValueChanged;

				pI.Name_Driver.SelectedValueChanged -= pI.Name_HeadOfMission_SelectedValueChanged;



				MyFunction.FillComboBox(pI.Name_HeadOfMission, HeadOfmission, Display, valuem);
				
				MyFunction.FillComboBox(pI.Name_HeadOfShift, HeadOfshift, Display, valuem);

				MyFunction.FillComboBox(pI.Name_Paramedic1, paramedic1, Display, valuem);

				MyFunction.FillComboBox(pI.Name_Paramedic2, paramedic2, Display, valuem);
				
				MyFunction.FillComboBox(pI.Name_RecipientOfMission, recipientOfMission, Display, valuem);

				MyFunction.FillComboBox(pI.Name_Driver, Driver, Display, valuem);



				pI.Name_HeadOfMission.SelectedValueChanged += pI.Name_HeadOfMission_SelectedValueChanged;

				pI.Name_HeadOfShift.SelectedValueChanged += pI.Name_HeadOfMission_SelectedValueChanged;

				pI.Name_Paramedic1.SelectedValueChanged += pI.Name_HeadOfMission_SelectedValueChanged;

				pI.Name_Paramedic2.SelectedValueChanged += pI.Name_HeadOfMission_SelectedValueChanged;

				pI.Name_RecipientOfMission.SelectedValueChanged += pI.Name_HeadOfMission_SelectedValueChanged;

				pI.Name_Driver.SelectedValueChanged += pI.Name_HeadOfMission_SelectedValueChanged;

				
				return true;
			}
			catch (Exception ex)
			{
				
				
				
				
				
				

				return false;
			}


		}
	}


	class Patient
	{
		public Patient()
		{

		}

        #region variables
        private string name;
		private int? insuranceID;
		private int? weight;
		private int? cityid;
		private int? regionid;
		private DateTime? dateOfBirth;
		private int? doctorID;
		private string phone;
		private string moreInfo;
        #endregion

        #region Proprties

		public string MoreInfo
		{
			get { return moreInfo; }
			set { moreInfo = value; }
		}
        public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public Nullable<int> InsuranceID
		{
			get { return insuranceID; }
			set { insuranceID = value; }
		}
		public int? Weight
		{
			get { return weight; }
			set { weight = value; }
		}
		public int? CityID
		{
			get { return cityid; }
			set { cityid = value; }
		}
		public int? RegionID
		{
			get { return regionid; }
			set { regionid = value; }
		}
	    
		public DateTime? DateOfBirth
		{
			get { return dateOfBirth; }
			set { dateOfBirth = value; }
		}
		public int? DoctorID
		{
			get { return doctorID; }
			set { doctorID = value; }
		}
		public string Phone
		{
			get { return phone; }
			set { phone = value; }
		}
        #endregion

        #region Fuctions
		public bool ImportPatient( AddPatient addPatient)
		{
			try
			{
				if(addPatient.NNAME.Text == "")
				{
					MessageBox.Show("املأ كل المعلومات");
					return false;
				}
				else
				{
					Name = addPatient.NNAME.Text;
				}

				try 
				{
					InsuranceID = int.Parse(addPatient.Insurancebox.SelectedValue.ToString());
				}
				catch
				{
					InsuranceID = null;
				}

				try
				{
					Weight = int.Parse(addPatient.Weight.Text);
				}
				catch
				{
					MessageBox.Show("املأ كل المعاومات");
				}

				try
				{
					DateOfBirth = addPatient.DateOfBirth.Value;
				}
				catch
				{
					MessageBox.Show("املأ كل المعاومات");
				}

				try
				{
					CityID = int.Parse(addPatient.CityBox.SelectedValue.ToString());

					RegionID = int.Parse(addPatient.RegionBox.SelectedValue.ToString());
				}
				catch
				{
					RegionID = null;
				}

				Phone = addPatient.Phone.Text;

				MoreInfo = addPatient.textBox1.Text;

				return true;
			}
			catch
			{
				return false;
			}
		}
		public int AddPatient()
		{
			try
			{
				المرضى patient = new المرضى();
				//patient.الرمز = 1;
				patient.اسم = Name;
				patient.الطبيب_المعالج = doctorID;
				patient.وزن = 70;
				//patient.رمز_المدينة = CityID;
				patient.رمز_المنطقة = RegionID;
				patient.الهاتف = Phone;
				patient.الضمان = InsuranceID;
				patient.العنوان = MoreInfo;
				patient.تاريخ_الولادة = DateOfBirth;
				patient.أمراض_مزمنة = null;
				
				return Hospital.add_Patient(patient);

			}
			catch
			{
				MessageBox.Show("rr");
				return -1;
			}


				

		}
        #endregion


    }
    class Hospitals
	{
		public Hospitals()
		{

		}

		public static DataTable GetHospitals()
		{
			return Erc1.Classes.Hospital.Get_Info_Hospital();
		}
		public static DataTable GetDepartement(int HosID)
		{
			return Erc1.Classes.Hospital.Get_أقسام_المستشفى(HosID);
		}
		public static bool SaveHospitale(DataRow dr)
		{
			Erc1.Classes.Hospital.UpdateHospitalStatus(dr);
			return true;
			    
		}
	}	
	class Cars
	{
		public Cars()
		{

		}

		public static IEnumerable getAmbulances(int centerID)
		{
			return Classes.mission.Getالآليات_by_المركز(centerID);
		}
	}




	static class ImportFromDrive
	{
		static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
		static readonly string ApplicationName="";
		static readonly string ID = "1xU4nKY-GN5VEEl_RkuiIprVWJKwbHqrkk7mFEciaCbM";
		static readonly string sheet = "Form responses 1";
		static SheetsService service;


		static DataTable carsInfo;
		public static DataTable ReadEnteries()
		{
			// carID      center       engins      HeadOfmission      Driver      Paramedic1       Paramedic2 

			GoogleCredential credential;
			using (var stream = new FileStream("ace-beanbag-226012-6d2433b6d430.json", FileMode.Open, FileAccess.Read))
			{
				credential = GoogleCredential.FromStream(stream)
					.CreateScoped(Scopes);
			}
			service = new SheetsService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = ApplicationName,

			});

			var valueRange = new ValueRange { Values = new[] { new object[] { "=COUNTA(A:A)" } } };
			var req = service.Spreadsheets.Values.Update(valueRange, ID, "K2");
			req.ValueInputOption = ValueInputOptionEnum.USERENTERED;
			req.IncludeValuesInResponse = true;
			req.ResponseValueRenderOption = ResponseValueRenderOptionEnum.UNFORMATTEDVALUE;
			var resp = req.Execute();
			int count = int.Parse(resp.UpdatedData.Values[0][0].ToString()) ;




			var range = $"{sheet}!A:G";
			var request = service.Spreadsheets.Values.Get(ID, range);
			var response = request.Execute();
			var values = response.Values;

			DataTable CarsInfo = new DataTable();
			CarsInfo.Columns.Add("Ambulance");
			CarsInfo.Columns.Add("HeadOfMission(ID)");
			CarsInfo.Columns.Add("Driver(ID)");
			CarsInfo.Columns.Add("Paramedic1");
			CarsInfo.Columns.Add("Paramedic2");
			CarsInfo.Columns.Add("fuel");

			DataRow dr;

			for (int i=1;i<count;i++)
			{
				dr = CarsInfo.NewRow();
				dr[0] = values[i][1].ToString();
				dr[1] = values[i][2].ToString();
				dr[2] = values[i][3].ToString();
				dr[3] = values[i][4].ToString();
				dr[4] = values[i][5].ToString();
				dr[5] = values[i][6].ToString();
				CarsInfo.Rows.Add(dr);
			}
			carsInfo = CarsInfo;

			return CarsInfo;

		}

		public static DataRow ReadCarInfo(int CarID)
		{
			if (carsInfo == null) 
			{
				return null;
			}
			foreach (DataRow row in carsInfo.Rows)
			{
				if(row[0].ToString() == CarID.ToString())
				{
					return row;
				}
			}
			return null;
		}
	}





}
