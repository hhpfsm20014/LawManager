using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;


public class DBActivity
{
    public DataTable GetUserProfileDetails(string Uid, string pw)
    {
        ClsDBConnection conn = new ClsDBConnection();

        try
        {
            SqlConnection cn = conn.OpenConnection(); //establishing the connection to database

            string qry = "select * from User_Master where (email_id =@email) AND (pwd=@pw)";

            SqlCommand cmd = new SqlCommand(qry, cn); //object created
            //cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@pw", pw);
            cmd.Parameters.AddWithValue("@email", Uid);
            //query executed
            //cmd.CommandText = "select * from '" + u_type + "' where (email_id ='" + Uid + "') AND (pwd='" + pw + "')";
            cmd.ExecuteNonQuery();

            DataTable dtReturn = new DataTable(); //object created
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dtReturn); //data is filled in table
            cmd.Parameters.Clear();
            return dtReturn;
        }
        catch (Exception ee)
        {
            return null;
            throw ee;
        }
        finally
        {
            conn.CloseConnection();
        }

    }

    public bool NewUserDetails(string c_name, string c_type, string c_person, string c_no, string adds, string city, String pincode, String state, String country, String e_id, String pwd)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {


            long c_id = objhdcon.GetCurrentAutoNumber(cmnd, "Client_Master");
            long u_id = objhdcon.GetCurrentAutoNumber(cmnd, "User_Master");
            string emailUser = null, emailClient = null; cmnd.Parameters.Clear();
            // cmnd.Parameters.Add(new OleDbParameter("@User_ID",User_ID));
            // cmnd.Parameters.Add(new OleDbParameter("@Name", Name));
            // cmnd.Parameters.Add(new OleDbParameter("@Address",Address));
            // cmnd.Parameters.Add(new OleDbParameter("@Birthdate",Birthdate));
            // cmnd.Parameters.Add(new OleDbParameter("@Mobile",Mobile));
            // cmnd.Parameters.Add(new OleDbParameter("@Email",Email));
            // cmnd.Parameters.Add(new OleDbParameter("@Pwd",Pwd));
            // cmnd.Parameters.Add(new OleDbParameter("@Reg_date",DateTime.Now));
            cmnd.CommandText = "Select email_id from User_Master where (email_id =@eid)";
            cmnd.Parameters.Add(new SqlParameter("eid", e_id));
            SqlDataReader dr = cmnd.ExecuteReader();
            //string email = dr.GetStringOrNull(0);
            if (dr.Read())
            {
                emailUser = dr.GetStringOrNull(0);

            } dr.Close();
            cmnd.Parameters.Clear();
            cmnd.CommandText = "Select email_id from Client_Master where (email_id =@eid)";
            cmnd.Parameters.Add(new SqlParameter("eid", e_id));
            SqlDataReader dr1 = cmnd.ExecuteReader();
            if (dr1.Read())
            {
                emailClient = dr1.GetStringOrNull(0);

            } dr1.Close();
            cmnd.Parameters.Clear();
            if (emailUser != e_id && emailClient != e_id)
            {

                cmnd.CommandText = "INSERT INTO Client_Master(client_id,company_name,client_industry,contact_person,contact_no,address,city,pincode,state,country,email_id,Pwd,user_id) VALUES(@cid,@cname,@cind,@cper,@cno,@add,@city,@pincode,@state,@country,@email,@pwd,@uid)";
                cmnd.Parameters.Add(new SqlParameter("cid", c_id));
                cmnd.Parameters.Add(new SqlParameter("cname", c_name));
                cmnd.Parameters.Add(new SqlParameter("cind", c_type));
                cmnd.Parameters.Add(new SqlParameter("cper", c_person));
                cmnd.Parameters.Add(new SqlParameter("cno", c_no));
                cmnd.Parameters.Add(new SqlParameter("add", adds));
                cmnd.Parameters.Add(new SqlParameter("city", city));
                cmnd.Parameters.Add(new SqlParameter("pincode", pincode));
                cmnd.Parameters.Add(new SqlParameter("state", state));
                cmnd.Parameters.Add(new SqlParameter("country", country));
                cmnd.Parameters.Add(new SqlParameter("email", e_id));
                cmnd.Parameters.Add(new SqlParameter("pwd", pwd));
                cmnd.Parameters.Add(new SqlParameter("uid", u_id));

                cmnd.ExecuteNonQuery();

                cmnd.Parameters.Clear();
                cmnd.CommandText = "INSERT INTO User_Master(user_id,user_name,pwd,user_type,email_id,contact_no,working_location,status) VALUES(@uid,@cper,@pwd,@utype,@eid,@cno,@city,@status)";

                cmnd.Parameters.Add(new SqlParameter("uid", u_id));
                cmnd.Parameters.Add(new SqlParameter("cper", c_person));
                cmnd.Parameters.Add(new SqlParameter("pwd", pwd));
                cmnd.Parameters.Add(new SqlParameter("utype", "viewer"));
                cmnd.Parameters.Add(new SqlParameter("eid", e_id));
                cmnd.Parameters.Add(new SqlParameter("cno", c_no));
                cmnd.Parameters.Add(new SqlParameter("city", city));
                cmnd.Parameters.Add(new SqlParameter("status", "active"));


                cmnd.ExecuteNonQuery();
                cmnd.Parameters.Clear();
                trans.Commit();

                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ee)
        {
            trans.Rollback();
            return false;
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public long ProjectSubmit(string p_name, string p_description, string p_start, string p_End, string EntryDate, string Category, string Court, string htmltext, string NameOfParty, string Oppositions, string ContactDetails, string Lawyer, string LawyerContact, string NatureOfCase, string CaseId, Int32 CategoryId, Int32 CourtId, string OppoContactDetails, string OppoLawyer, string OppoLawyerContact, Int32 UserId, int DistrictID)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();
            long p_id = objhdcon.GetCurrentAutoNumber(cmnd, "Project_Master");

            cmnd.CommandText = "INSERT INTO Project_Master(project_id,project_name,project_description,start_date,end_date,EntryDate,Category,Court,HTMLDescription,NameOfParty,Oppositions,ContactDetails,Lawyer,LaywerContactDetails,OppoContactDetails,OppoLawyer,OppoLaywerContactDetails,NatureOfCase,CaseId,CategoryId,CourtId, user_id,DistrictID) VALUES(@pid,@pname,@pdesc,@start_date,@end_date,@EntryDate,@Category,@Court,@htmltext,@NameOfParty,@Oppositions,@ContactDetails,@Lawyer,@LawyerContact,@OppoContactDetails,@OppoLawyer,@OppoLawyerContact,@NatureOfCase,@CaseId,@CategoryId,@CourtId,@UserId,@DistrictID)";
            //cmnd.CommandText = "INSERT INTO Project_Master(project_id,project_name,project_description,start_date,end_date,Category,Court,HTMLDescription,NameOfParty,Oppositions,ContactDetails,Lawyer,LaywerContactDetails,NatureOfCase,CaseId) VALUES(@pid,@pname,@pdesc,@start_date,@end_date,@Category,@Court,@htmltext,@NameOfParty,@Oppositions,@ContactDetails,@Lawer,@LawyerContact,@NatureOfCase,@CaseId)";
            cmnd.Parameters.Add(new SqlParameter("pid", p_id));
            cmnd.Parameters.Add(new SqlParameter("pname", p_name));
            cmnd.Parameters.Add(new SqlParameter("pdesc", htmltext));
            cmnd.Parameters.Add(new SqlParameter("start_date", p_start));
            cmnd.Parameters.Add(new SqlParameter("end_date", p_End));
            cmnd.Parameters.Add(new SqlParameter("EntryDate", EntryDate));
            cmnd.Parameters.Add(new SqlParameter("Category", Category));
            cmnd.Parameters.Add(new SqlParameter("Court", Court));
            cmnd.Parameters.Add(new SqlParameter("htmltext",p_description ));
            cmnd.Parameters.Add(new SqlParameter("NameOfParty", NameOfParty));
            cmnd.Parameters.Add(new SqlParameter("Oppositions", Oppositions));
            cmnd.Parameters.Add(new SqlParameter("ContactDetails", ContactDetails));
            cmnd.Parameters.Add(new SqlParameter("Lawyer", Lawyer));
            cmnd.Parameters.Add(new SqlParameter("LawyerContact", LawyerContact));
            cmnd.Parameters.Add(new SqlParameter("OppoContactDetails", OppoContactDetails));
            cmnd.Parameters.Add(new SqlParameter("OppoLawyer", OppoLawyer));
            cmnd.Parameters.Add(new SqlParameter("OppoLawyerContact", OppoLawyerContact));
            cmnd.Parameters.Add(new SqlParameter("NatureOfCase", NatureOfCase));
            cmnd.Parameters.Add(new SqlParameter("CaseId", CaseId));
            cmnd.Parameters.Add(new SqlParameter("CategoryId", CategoryId));
            cmnd.Parameters.Add(new SqlParameter("CourtId", CourtId));
            cmnd.Parameters.Add(new SqlParameter("UserId", UserId));
            cmnd.Parameters.Add(new SqlParameter("DistrictID", DistrictID));
            
            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return p_id;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public bool CategorySubmit(string C_name)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            string CategoryName = null;
            cmnd.Parameters.Clear();

            cmnd.CommandText = "Select CategoryName from CaseCategory where (CategoryName =@cname)";
            cmnd.Parameters.Add(new SqlParameter("cname", C_name));
            SqlDataReader dr = cmnd.ExecuteReader();
            //string email = dr.GetStringOrNull(0);
            if (dr.Read())
            {
                CategoryName = dr.GetStringOrNull(0);

            } dr.Close();
            cmnd.Parameters.Clear();
            //long p_id = objhdcon.GetCurrentAutoNumber(cmnd, "Project_Master");
            if (CategoryName != C_name)
            {
                cmnd.CommandText = "INSERT INTO CaseCategory (CategoryName) VALUES(@cname)";
                cmnd.Parameters.Add(new SqlParameter("cname", C_name));

                cmnd.ExecuteNonQuery();
                cmnd.Parameters.Clear();
                trans.Commit();

                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public bool CourtSubmit(string C_name)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            string CourtName = null;
            cmnd.Parameters.Clear();

            cmnd.CommandText = "Select CourtName from Court where (CourtName =@cname)";
            cmnd.Parameters.Add(new SqlParameter("cname", C_name));
            SqlDataReader dr = cmnd.ExecuteReader();
            //string email = dr.GetStringOrNull(0);
            if (dr.Read())
            {
                CourtName = dr.GetStringOrNull(0);

            } dr.Close();
            cmnd.Parameters.Clear();
            //long p_id = objhdcon.GetCurrentAutoNumber(cmnd, "Project_Master");
            if (CourtName != C_name)
            {
                cmnd.CommandText = "INSERT INTO Court (CourtName) VALUES(@cname)";
                cmnd.Parameters.Add(new SqlParameter("cname", C_name));

                cmnd.ExecuteNonQuery();
                cmnd.Parameters.Clear();
                trans.Commit();

                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public bool moduleSubmit(string txtProjectId, string txtModuleName, string txtModuleDesc)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();

            long m_id = objhdcon.GetCurrentAutoNumber(cmnd, "Project_Module");

            cmnd.CommandText = "INSERT INTO Project_Module(project_id,module_id,module_name,module_description) VALUES(@pid,@mid,@mname,@mdesc)";

            cmnd.Parameters.Add(new SqlParameter("pid", txtProjectId));
            cmnd.Parameters.Add(new SqlParameter("mid", m_id));
            cmnd.Parameters.Add(new SqlParameter("mname", txtModuleName));
            cmnd.Parameters.Add(new SqlParameter("mdesc", txtModuleDesc));

            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return true;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            return false;
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public bool createUser(string txtName, string txtEmail, string txtContactNo, string ddlType, string radioStatus, string txtPassword)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();

            long u_id = objhdcon.GetCurrentAutoNumber(cmnd, "User_Master");

            cmnd.CommandText = "INSERT INTO User_Master(user_id,user_name,email_id,contact_no,user_type,status,pwd) VALUES(@uid,@uname,@eid,@contno,@utype,@status,@pwd)";

            cmnd.Parameters.Add(new SqlParameter("uid", u_id));
            cmnd.Parameters.Add(new SqlParameter("uname", txtName));
            cmnd.Parameters.Add(new SqlParameter("eid", txtEmail));
            cmnd.Parameters.Add(new SqlParameter("contno", txtContactNo));
            cmnd.Parameters.Add(new SqlParameter("utype", ddlType));
            cmnd.Parameters.Add(new SqlParameter("status", radioStatus));
            cmnd.Parameters.Add(new SqlParameter("pwd", txtPassword));

            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return true;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            return false;
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public long EditProject(Int32 ProjectId, string p_name, string p_description, string p_start, string p_End, string EntryDate, string Category, string Court, string htmltext, string NameOfParty, string Oppositions, string ContactDetails, string Lawyer, string LawyerContact, string NatureOfCase, string CaseId, Int32 CategoryId, Int32 CourtId, string OppoContactDetails, string OppoLawyer, string OppoLawyerContact, int DistrictID)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();


        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();
            //cmnd.CommandText = "INSERT INTO Project_Master(project_id,project_name,project_description,start_date,end_date,EntryDate,Category,Court,HTMLDescription,NameOfParty,Oppositions,ContactDetails,Lawyer,LaywerContactDetails,NatureOfCase,CaseId,CategoryId,CourtId) VALUES(@pid,@pname,@pdesc,@start_date,@end_date,@EntryDate,@Category,@Court,@htmltext,@NameOfParty,@Oppositions,@ContactDetails,@Lawer,@LawyerContact,@NatureOfCase,@CaseId,@CategoryId,@CourtId)";
            cmnd.CommandText = "UPDATE Project_Master SET project_name=@pname,project_description=@pdesc,HTMLDescription=@htmltext,start_date=@start_date,end_date=@end_date,CategoryId=@CategoryId,CourtId=@CourtId,Category=@Category,Court=@Court,NameOfParty=@NameOfParty,Oppositions=@Oppositions,ContactDetails=@ContactDetails,Lawyer=@Lawyer,LaywerContactDetails=@LawyerContact,OppoContactDetails=@OppoContactDetails,OppoLawyer=@OppoLawyer,OppoLaywerContactDetails=@OppoLawyerContact,NatureOfCase=@NatureOfCase,CaseId=@CaseId ,DistrictID=@DistrictID WHERE project_id =@pid";

            cmnd.Parameters.Add(new SqlParameter("pid", ProjectId));
            cmnd.Parameters.Add(new SqlParameter("pname", p_name));
            cmnd.Parameters.Add(new SqlParameter("pdesc", htmltext));
            cmnd.Parameters.Add(new SqlParameter("start_date", p_start));
            cmnd.Parameters.Add(new SqlParameter("end_date", p_End));
            cmnd.Parameters.Add(new SqlParameter("EntryDate", EntryDate));
            cmnd.Parameters.Add(new SqlParameter("Category", Category));
            cmnd.Parameters.Add(new SqlParameter("Court", Court));
            cmnd.Parameters.Add(new SqlParameter("htmltext", p_description));
            cmnd.Parameters.Add(new SqlParameter("NameOfParty", NameOfParty));
            cmnd.Parameters.Add(new SqlParameter("Oppositions", Oppositions));
            cmnd.Parameters.Add(new SqlParameter("ContactDetails", ContactDetails));
            cmnd.Parameters.Add(new SqlParameter("Lawyer", Lawyer));
            cmnd.Parameters.Add(new SqlParameter("LawyerContact", LawyerContact));
            cmnd.Parameters.Add(new SqlParameter("OppoContactDetails", OppoContactDetails));
            cmnd.Parameters.Add(new SqlParameter("OppoLawyer", OppoLawyer));
            cmnd.Parameters.Add(new SqlParameter("OppoLawyerContact", OppoLawyerContact));
            cmnd.Parameters.Add(new SqlParameter("NatureOfCase", NatureOfCase));
            cmnd.Parameters.Add(new SqlParameter("CaseId", CaseId));
            cmnd.Parameters.Add(new SqlParameter("CategoryId", CategoryId));
            cmnd.Parameters.Add(new SqlParameter("CourtId", CourtId));
            cmnd.Parameters.Add(new SqlParameter("DistrictID", DistrictID));
            

            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return ProjectId;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;

        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public bool EditModule(string module_id, string modulename, string moduledescription)
    {

        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();

        //string qry = "SELECT project_id FROM Project_Master where project_name = '" + projectname + "'";
        //SqlCommand cmd = new SqlCommand(qry, cn); //object created
        ////cmd.ExecuteNonQuery();
        //SqlDataReader dr = cmd.ExecuteReader();

        //DataTable dtReturn = new DataTable(); //object created
        //SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //adp.Fill(dtReturn);

        //string p_id = dtReturn.Rows.ToString();

        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();

            cmnd.CommandText = "UPDATE Project_Module SET module_name =@mname,module_description=@mdesc WHERE module_id LIKE @mid";

            cmnd.Parameters.Add(new SqlParameter("mname", modulename));
            cmnd.Parameters.Add(new SqlParameter("mdesc", moduledescription));
            cmnd.Parameters.Add(new SqlParameter("mid", module_id));


            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return true;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;

        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public long IssueSubmit(string projectid, string issuedesc,  string notes, int userid,string nextDate)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();

            long i_id = objhdcon.GetCurrentAutoNumber(cmnd, "Issue_Master");
            //string date = DateTime.Today.ToShortDateString();
            cmnd.CommandText = "INSERT INTO Issue_Master(issue_id,project_id,issue_description,submit_date,issue_notes,admin_id,nxtHearingDate) VALUES(@issueid,@pid,@idesc,@submitdate,@notes,@uid,@NextDatedate)";
            cmnd.Parameters.Add(new SqlParameter("issueid", i_id));
            cmnd.Parameters.Add(new SqlParameter("pid", projectid));
            
            cmnd.Parameters.Add(new SqlParameter("idesc", issuedesc));
            cmnd.Parameters.Add(new SqlParameter("NextDatedate", nextDate));
            cmnd.Parameters.Add(new SqlParameter("notes", notes));
            cmnd.Parameters.Add(new SqlParameter("uid", userid));
            cmnd.Parameters.Add(new SqlParameter("submitdate", DateTime.Now));

            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return i_id;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public bool IssueUpdate(Int32 issueID,string IssueDesc)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();

        

        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            string modified = DateTime.Now.ToString();
            cmnd.Parameters.Clear();

            cmnd.CommandText = "UPDATE Issue_Master SET prevHearingDes =@idesc,last_modified_date =@modified WHERE issue_id = @iid";
            
            cmnd.Parameters.Add(new SqlParameter("idesc", IssueDesc));
            
            
            cmnd.Parameters.Add(new SqlParameter("modified", modified));
            cmnd.Parameters.Add(new SqlParameter("iid", issueID));


            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return true;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;

        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public bool IssueDataUpdate(Int32 IssueID, string IssueDesc, string PrvIssuedesc, string Notes, string NextDate)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();



        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            string modified = DateTime.Now.ToString();
            cmnd.Parameters.Clear();

            cmnd.CommandText = "UPDATE Issue_Master SET prevHearingDes =@predesc,issue_description=@idesc,last_modified_date =@modified,issue_notes=@notes,nxtHearingDate=@NextDate WHERE issue_id = @iid";

            cmnd.Parameters.Add(new SqlParameter("predesc", PrvIssuedesc));
            cmnd.Parameters.Add(new SqlParameter("modified", modified));
            cmnd.Parameters.Add(new SqlParameter("iid", IssueID));
            cmnd.Parameters.Add(new SqlParameter("idesc", IssueDesc));
            cmnd.Parameters.Add(new SqlParameter("NextDate", NextDate));
            cmnd.Parameters.Add(new SqlParameter("notes", Notes));


            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return true;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;

        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public bool addUser(string ddlProject, string ddlModule, string ddlIssue, string rblPriority, string startDate, string EndDate, string issueNotes, string user_ids)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();

            long a_id = objhdcon.GetCurrentAutoNumber(cmnd, "Modulewise_Issue_Assignment");

            cmnd.CommandText = "INSERT INTO Modulewise_Issue_Assignment(issue_assignment_id, project_id, module_id, issue_id, assigned_to, priority, start_date, end_date, issue_notes) VALUES(@aid,@pid,@mid,@iid,@assignto,@priority,@start,@end,@issueNotes)";
            cmnd.Parameters.Add(new SqlParameter("aid", a_id));
            cmnd.Parameters.Add(new SqlParameter("pid", ddlProject));
            cmnd.Parameters.Add(new SqlParameter("mid", ddlModule));
            cmnd.Parameters.Add(new SqlParameter("iid", ddlIssue));
            cmnd.Parameters.Add(new SqlParameter("assignto", user_ids));
            cmnd.Parameters.Add(new SqlParameter("priority", rblPriority));
            cmnd.Parameters.Add(new SqlParameter("start", startDate));
            cmnd.Parameters.Add(new SqlParameter("end", EndDate));
            cmnd.Parameters.Add(new SqlParameter("issueNotes", issueNotes));

            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();


            cmnd.CommandText = "UPDATE Issue_Master SET issue_status =@iStatus,issue_priority=iPriority WHERE issue_id = @iid";
            cmnd.Parameters.Add(new SqlParameter("iStatus", "assigned"));
            cmnd.Parameters.Add(new SqlParameter("iPriority", rblPriority));
            cmnd.Parameters.Add(new SqlParameter("iid", ddlIssue));

            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return true;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            return false;
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public bool EditIssue(string issueID, string IssueType, string IssueDesc, string priority, string reproducibility, string steps, string notes, string status)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();

        //string qry = "SELECT issue_id FROM Issue_Master where issue_name = '" + IssueName + "'";
        //SqlCommand cmd = new SqlCommand(qry, cn); //object created
        ////cmd.ExecuteNonQuery();
        //SqlDataReader dr = cmd.ExecuteReader();

        //DataTable dtReturn = new DataTable(); //object created
        //SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //adp.Fill(dtReturn);

        //string p_id = dtReturn.Rows.ToString();

        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            string modified = DateTime.Now.ToString();
            cmnd.Parameters.Clear();

            cmnd.CommandText = "UPDATE Issue_Master SET issue_type =@itype,issue_description =@idesc,issue_priority =@iprior,reproducibility =@repro,stepReproduce =@stepsrepro,issue_notes =@inotes,issue_status =@istatus,last_modified_date =@modified WHERE issue_id = @iid";
            cmnd.Parameters.Add(new SqlParameter("itype", IssueType));
            cmnd.Parameters.Add(new SqlParameter("idesc", IssueDesc));
            cmnd.Parameters.Add(new SqlParameter("iprior", priority));
            cmnd.Parameters.Add(new SqlParameter("repro", reproducibility));
            cmnd.Parameters.Add(new SqlParameter("stepsrepro", steps));
            cmnd.Parameters.Add(new SqlParameter("inotes", notes));
            cmnd.Parameters.Add(new SqlParameter("istatus", status));
            cmnd.Parameters.Add(new SqlParameter("modified", modified));
            cmnd.Parameters.Add(new SqlParameter("iid", issueID));


            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return true;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;

        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public string fileUploading(string fileName, string actualname, string filePath,long projectid, string issue_id)
    {

        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();

            long f_id = objhdcon.GetCurrentAutoNumber(cmnd, "File_Sharing_Info");
            string date = System.DateTime.Today.ToShortDateString();
            cmnd.CommandText = "INSERT INTO File_Sharing_Info(file_id,file_name,file_path,project_id,issue_id,actualname,submitdatetime) VALUES(@fid,@fname,@fpath,@pid,@iid,@aname,@date)";
            cmnd.Parameters.Add(new SqlParameter("fid", f_id));
            cmnd.Parameters.Add(new SqlParameter("fname", fileName));
            cmnd.Parameters.Add(new SqlParameter("fpath", filePath));
            cmnd.Parameters.Add(new SqlParameter("pid", projectid));
            cmnd.Parameters.Add(new SqlParameter("iid", issue_id));
            cmnd.Parameters.Add(new SqlParameter("aname", actualname));
            cmnd.Parameters.Add(new SqlParameter("date", date));
            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();
            return (string)Convert.ToString(f_id);

        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }

    }

    //public SqlDataReader issueDetails(string issueID)
    //{
    //    ClsDBConnection objhdcon = new ClsDBConnection();
    //    SqlConnection cn = objhdcon.OpenConnection();
    //    SqlCommand cmnd = new SqlCommand();
    //    cmnd.Connection = cn;
    //    try
    //    {
    //        cmnd.Parameters.Clear();
    //        string qry = "SELECT * FROM Issue_Master WHERE(issue_id = '" + issueID + "')";
    //        SqlCommand cmd = new SqlCommand(qry, cn);
    //        SqlDataReader dr = cmd.ExecuteReader();
    //        dr.Close();
    //        return dr;

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally {

    //    }
    //}
    public bool addNote(string i_id, string f_id, string user_id, string c_state)
    {

        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();

            long c_id = objhdcon.GetCurrentAutoNumber(cmnd, "Comment");
            string date = System.DateTime.Now.ToString();
            if (f_id == null)
            {
                cmnd.CommandText = "INSERT INTO Comment(comment_id,user_id,comment_statement, issue_id, submitdatetime) VALUES(@cid,@uid,@cstatement,@iid,@date)";
                cmnd.Parameters.Add(new SqlParameter("cid", c_id));
                cmnd.Parameters.Add(new SqlParameter("uid", user_id));
                cmnd.Parameters.Add(new SqlParameter("cstatement", c_state));
                cmnd.Parameters.Add(new SqlParameter("iid", i_id));
                cmnd.Parameters.Add(new SqlParameter("date", date));

            }
            else
            {
                cmnd.CommandText = "INSERT INTO Comment(comment_id,user_id,comment_statement, file_id, submitdatetime) VALUES(@cid,@uid,@cstatement,@fid,@date)";
                cmnd.Parameters.Add(new SqlParameter("cid", c_id));
                cmnd.Parameters.Add(new SqlParameter("uid", user_id));
                cmnd.Parameters.Add(new SqlParameter("cstatement", c_state));
                cmnd.Parameters.Add(new SqlParameter("fid", f_id));
                cmnd.Parameters.Add(new SqlParameter("date", date));
            }

            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();
            return true;

        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }

    }

    //public string Comment(string CommentStatement, string fileID, string ddlissue)
    //{

    //    ClsDBConnection objhdcon = new ClsDBConnection();
    //    SqlConnection cn = objhdcon.OpenConnection();
    //    SqlCommand cmnd = new SqlCommand();
    //    SqlTransaction trans;
    //    trans = cn.BeginTransaction();
    //    cmnd.Connection = cn;
    //    cmnd.Transaction = trans;

    //    try
    //    {
    //        cmnd.Parameters.Clear();

    //        long c_id = objhdcon.GetCurrentAutoNumber(cmnd, "Comment");
    //        string date = System.DateTime.Today.ToShortDateString();
    //        cmnd.CommandText = "INSERT INTO Comment(comment_id,file_id,comment_statement,issue_id,submitdatetime) VALUES('" + c_id + "','" + fileID + "','" + CommentStatement + "','" + ddlissue + "','" + date + "')";

    //        cmnd.ExecuteNonQuery();

    //        trans.Commit();

    //        return (string)Convert.ToString(c_id);



    //    }
    //    catch (Exception ee)
    //    {
    //        trans.Rollback();
    //        throw ee;
    //    }
    //    finally
    //    {
    //        objhdcon.CloseConnection();
    //    }

    //}

    public void sendMail(string sendto, string subject, string body)
    {


        string pw = "mafiamafia"; //(ConfigurationManager.AppSettings["password"]);
        string from = "mafiaboy5800@gmail.com"; //Replace this with your own correct Gmail Address
        string to = sendto; //Replace this with the Email Address to whom you want to send the mail
        // used in body, Name of user
        // if needed
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from);
        mail.Subject = subject;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = body;
        mail.Priority = MailPriority.High;
        SmtpClient client = new SmtpClient();

        //Add the Creddentials- use your own email id and password
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential(from, pw);
        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer

        try
        {
            client.Send(mail);
            /// return label stating mail is sent;
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        }


    }

    public void sendSMS(string no, string msg)
    {
        try
        {
            HttpWebRequest myReq =
            (HttpWebRequest)WebRequest.Create("http://ubaid.tk/sms/sms.aspx?uid=9998544799&pwd=attitude" + "&msg=" + msg + "&phone=" + no + "&provider=site2sms");

            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }
        catch (Exception ee)
        { }

    }

    public bool EditUser(string UserID, string Name, string ddlAccess)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();


        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();

            cmnd.CommandText = "UPDATE User_Master SET user_name=@uname,user_type=@utype WHERE user_id = @uid";
            cmnd.Parameters.Add(new SqlParameter("uname", Name));
            cmnd.Parameters.Add(new SqlParameter("utype", ddlAccess));
            cmnd.Parameters.Add(new SqlParameter("uid", UserID));

            cmnd.ExecuteNonQuery();

            trans.Commit();

            return true;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;

        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }
    public bool AddusersProject(string userID, string Project, string ProjectName)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();

            long New_id = objhdcon.GetCurrentAutoNumber(cmnd, "New_Feature_Tracking");

            cmnd.CommandText = "INSERT INTO New_Feature_Tracking(new_feature_tracking_id,project_id,user_id,project_name) VALUES(@nid,@pid,@uid,@pname)";
            cmnd.Parameters.Add(new SqlParameter("nid", New_id));
            cmnd.Parameters.Add(new SqlParameter("pid", Project));
            cmnd.Parameters.Add(new SqlParameter("uid", userID));
            cmnd.Parameters.Add(new SqlParameter("pname", ProjectName));



            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return true;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public bool DeleteusersProject(string userID, string Project, string ProjectName)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();

            cmnd.CommandText = "DELETE * FROM New_Feature_Tracking WHERE(User_id = @uid AND project_id = @pid)";
            cmnd.Parameters.Add(new SqlParameter("uid", userID));
            cmnd.Parameters.Add(new SqlParameter("pid", Project));
            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return true;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }
    public bool updateOwn(string Uid,string Name, string pwd, string contno)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();


        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();

            cmnd.CommandText = "UPDATE User_Master SET user_name=@uname,pwd=@pwd,contact_no=@contno WHERE user_id = @uid";
            cmnd.Parameters.Add(new SqlParameter("uname", Name));
            cmnd.Parameters.Add(new SqlParameter("pwd", pwd));
            cmnd.Parameters.Add(new SqlParameter("contno", contno));
            cmnd.Parameters.Add(new SqlParameter("uid", Uid));
            cmnd.ExecuteNonQuery();

            trans.Commit();
            cmnd.Parameters.Clear();
            return true;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;

        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }
    public DataTable userDetail(string Uid)
    {
        ClsDBConnection conn = new ClsDBConnection();

        try
        {
            SqlConnection cn = conn.OpenConnection(); //establishing the connection to database


            string qry = "select * from User_Master where user_id=@uid";

            SqlCommand cmd = new SqlCommand(qry, cn); //object created
            //cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("uid", Uid));
            
            //query executed
            //cmd.CommandText = "select * from '" + u_type + "' where (email_id ='" + Uid + "') AND (pwd='" + pw + "')";
            cmd.ExecuteNonQuery();

            DataTable dtReturn = new DataTable(); //object created
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dtReturn); //data is filled in table
            cmd.Parameters.Clear();
            return dtReturn;
        }
        catch (Exception ee)
        {
            return null;
            throw ee;
        }
        finally
        {
            conn.CloseConnection();
        }

    }

    public long LandCaseSave(string CourtName, int DistrictID, string CaseNo, string CaseNature, string NameOfParty, string OppoNameOfParty, string PartyContact, string OppoPartyContact, string Lawyer, string OppoLawyer, string LawyerContact, string OppoLawyerContact, string LandSchedule, string PlaintDescription, string WSDescription, string PlaintWSDate, string NextDate, string NextDateReason, string CaseOutcome, string OutcomeDate, string AppealOrRevisionNo, string AppealOrRevisionFilingDate, string AppealCourtName, string plaintFilingDate, string AdvocateName, string DocumentHandoverDate, string DocumentHandoverList, string CourtSubmittedDocumentNote, string NextAppealDate, string NextAppealReason, string AppealOrRevisionResult, string Remark, Int32 UserId)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;
        bool IsDeleted = false;
        try
        {
            cmnd.Parameters.Clear();
            long LandCaseId = objhdcon.GetCurrentAutoNumber(cmnd, "LandCase");

            cmnd.CommandText = "INSERT INTO LandCase(LandCaseId,DistrictID,CourtName,CaseNo,CaseNature,NameOfParty,OppoNameOfParty,PartyContact,OppoPartyContact,Lawyer,OppoLawyer,LawyerContact"
                               + ",OppoLawyerContact,LandSchedule,PlaintDescription,WSDescription,PlaintWSDate,NextDate,NextDateReason,CaseOutcome,OutcomeDate,AppealOrRevisionNo"
                               +",AppealOrRevisionFilingDate,AppealCourtName,plaintFilingDate,AdvocateName,DocumentHandoverDate,DocumentHandoverList,CourtSubmittedDocumentNote,NextAppealDate"
                               + ",NextAppealReason,AppealOrRevisionResult,Remark,IsDeleted, UserId)"
                               + " VALUES(@LandCaseId,@DistrictID,@CourtName,@CaseNo,@CaseNature,@NameOfParty,@OppoNameOfParty,@PartyContact,@OppoPartyContact,@Lawyer,@OppoLawyer,@LawyerContact,@OppoLawyerContact"
                               + ",@LandSchedule,@PlaintDescription,@WSDescription,@PlaintWSDate,@NextDate,@NextDateReason,@CaseOutcome,@OutcomeDate,@AppealOrRevisionNo,@AppealOrRevisionFilingDate"
                               +",@AppealCourtName,@plaintFilingDate,@AdvocateName,@DocumentHandoverDate,@DocumentHandoverList,@CourtSubmittedDocumentNote,@NextAppealDate,@NextAppealReason"
                               +",@AppealOrRevisionResult,@Remark,@IsDeleted,@UserId)";
            
            cmnd.Parameters.Add(new SqlParameter("LandCaseId", LandCaseId));
            cmnd.Parameters.Add(new SqlParameter("DistrictID", DistrictID));
            cmnd.Parameters.Add(new SqlParameter("CourtName", CourtName));
            cmnd.Parameters.Add(new SqlParameter("CaseNo", CaseNo));
            cmnd.Parameters.Add(new SqlParameter("CaseNature", CaseNature));
            cmnd.Parameters.Add(new SqlParameter("NameOfParty", NameOfParty));
            cmnd.Parameters.Add(new SqlParameter("OppoNameOfParty", OppoNameOfParty));
            cmnd.Parameters.Add(new SqlParameter("PartyContact", PartyContact));
            cmnd.Parameters.Add(new SqlParameter("OppoPartyContact", OppoPartyContact));
            cmnd.Parameters.Add(new SqlParameter("Lawyer", Lawyer));
            cmnd.Parameters.Add(new SqlParameter("OppoLawyer", OppoLawyer));
            cmnd.Parameters.Add(new SqlParameter("OppoLawyerContact", OppoLawyerContact));
            cmnd.Parameters.Add(new SqlParameter("LandSchedule", LandSchedule));
            cmnd.Parameters.Add(new SqlParameter("LawyerContact", LawyerContact));
            cmnd.Parameters.Add(new SqlParameter("PlaintDescription", PlaintDescription));
            cmnd.Parameters.Add(new SqlParameter("WSDescription", WSDescription));
            cmnd.Parameters.Add(new SqlParameter("PlaintWSDate", PlaintWSDate));
            cmnd.Parameters.Add(new SqlParameter("NextDate", NextDate));
            cmnd.Parameters.Add(new SqlParameter("NextDateReason", NextDateReason));
            cmnd.Parameters.Add(new SqlParameter("CaseOutcome", CaseOutcome));
            cmnd.Parameters.Add(new SqlParameter("OutcomeDate", OutcomeDate));
            cmnd.Parameters.Add(new SqlParameter("AppealOrRevisionNo", AppealOrRevisionNo));
            cmnd.Parameters.Add(new SqlParameter("AppealOrRevisionFilingDate", AppealOrRevisionFilingDate));
            cmnd.Parameters.Add(new SqlParameter("AppealCourtName", AppealCourtName));
            cmnd.Parameters.Add(new SqlParameter("plaintFilingDate", plaintFilingDate));
            cmnd.Parameters.Add(new SqlParameter("AdvocateName", AdvocateName));
            cmnd.Parameters.Add(new SqlParameter("DocumentHandoverDate", DocumentHandoverDate));
            cmnd.Parameters.Add(new SqlParameter("DocumentHandoverList", DocumentHandoverList));
            cmnd.Parameters.Add(new SqlParameter("CourtSubmittedDocumentNote", CourtSubmittedDocumentNote));
            cmnd.Parameters.Add(new SqlParameter("NextAppealDate", NextAppealDate));
            cmnd.Parameters.Add(new SqlParameter("NextAppealReason", NextAppealReason));
            cmnd.Parameters.Add(new SqlParameter("AppealOrRevisionResult", AppealOrRevisionResult));
            cmnd.Parameters.Add(new SqlParameter("Remark", Remark));
            cmnd.Parameters.Add(new SqlParameter("IsDeleted", IsDeleted));
            cmnd.Parameters.Add(new SqlParameter("UserId", UserId));
            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return LandCaseId;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;
        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }

    public long LandCaseEdit(int LandCaseId, int DistrictID, string CourtName, string CaseNo, string CaseNature, string NameOfParty, string OppoNameOfParty, string PartyContact, string OppoPartyContact, string Lawyer, string OppoLawyer, string LawyerContact, string OppoLawyerContact, string LandSchedule, string PlaintDescription, string WSDescription, string PlaintWSDate, string NextDate, string NextDateReason, string CaseOutcome, string OutcomeDate, string AppealOrRevisionNo, string AppealOrRevisionFilingDate, string AppealCourtName, string plaintFilingDate, string AdvocateName, string DocumentHandoverDate, string DocumentHandoverList, string CourtSubmittedDocumentNote, string NextAppealDate, string NextAppealReason, string AppealOrRevisionResult, string Remark)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();


        SqlCommand cmnd = new SqlCommand();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        cmnd.Connection = cn;
        cmnd.Transaction = trans;

        try
        {
            cmnd.Parameters.Clear();
            cmnd.CommandText = "UPDATE LandCase SET "
            + "DistrictID=@DistrictID,CourtName = @CourtName,CaseNo = @CaseNo ,CaseNature = @CaseNature ,NameOfParty = @NameOfParty,OppoNameOfParty = @OppoNameOfParty ,PartyContact = @PartyContact"
            + ",OppoPartyContact = @OppoPartyContact ,Lawyer = @Lawyer ,OppoLawyer = @OppoLawyer  ,LawyerContact = @LawyerContact  ,OppoLawyerContact = @OppoLawyerContact"
            + ",LandSchedule = @LandSchedule ,PlaintDescription = @PlaintDescription  ,WSDescription = @WSDescription  ,PlaintWSDate = @PlaintWSDate,NextDate = @NextDate"
            + ",NextDateReason = @NextDateReason ,CaseOutcome = @CaseOutcome ,OutcomeDate = @OutcomeDate ,AppealOrRevisionNo = @AppealOrRevisionNo"
            + ",AppealOrRevisionFilingDate = @AppealOrRevisionFilingDate,AppealCourtName = @AppealCourtName,plaintFilingDate = @plaintFilingDate,AdvocateName = @AdvocateName"
            + ",DocumentHandoverDate = @DocumentHandoverDate,DocumentHandoverList = @DocumentHandoverList ,CourtSubmittedDocumentNote = @CourtSubmittedDocumentNote"
            + ",NextAppealDate = @NextAppealDate,NextAppealReason = @NextAppealReason,AppealOrRevisionResult = @AppealOrRevisionResult,Remark = @Remark"
            + " WHERE LandCaseId =@LandCaseId";

            cmnd.Parameters.Add(new SqlParameter("LandCaseId", LandCaseId));
            cmnd.Parameters.Add(new SqlParameter("DistrictID", DistrictID));
            cmnd.Parameters.Add(new SqlParameter("CourtName", CourtName));
            cmnd.Parameters.Add(new SqlParameter("CaseNo", CaseNo));
            cmnd.Parameters.Add(new SqlParameter("CaseNature", CaseNature));
            cmnd.Parameters.Add(new SqlParameter("NameOfParty", NameOfParty));
            cmnd.Parameters.Add(new SqlParameter("OppoNameOfParty", OppoNameOfParty));
            cmnd.Parameters.Add(new SqlParameter("PartyContact", PartyContact));
            cmnd.Parameters.Add(new SqlParameter("OppoPartyContact", OppoPartyContact));
            cmnd.Parameters.Add(new SqlParameter("Lawyer", Lawyer));
            cmnd.Parameters.Add(new SqlParameter("OppoLawyer", OppoLawyer));
            cmnd.Parameters.Add(new SqlParameter("OppoLawyerContact", OppoLawyerContact));
            cmnd.Parameters.Add(new SqlParameter("LandSchedule", LandSchedule));
            cmnd.Parameters.Add(new SqlParameter("LawyerContact", LawyerContact));
            cmnd.Parameters.Add(new SqlParameter("PlaintDescription", PlaintDescription));
            cmnd.Parameters.Add(new SqlParameter("WSDescription", WSDescription));
            cmnd.Parameters.Add(new SqlParameter("PlaintWSDate", PlaintWSDate));
            cmnd.Parameters.Add(new SqlParameter("NextDate", NextDate));
            cmnd.Parameters.Add(new SqlParameter("NextDateReason", NextDateReason));
            cmnd.Parameters.Add(new SqlParameter("CaseOutcome", CaseOutcome));
            cmnd.Parameters.Add(new SqlParameter("OutcomeDate", OutcomeDate));
            cmnd.Parameters.Add(new SqlParameter("AppealOrRevisionNo", AppealOrRevisionNo));
            cmnd.Parameters.Add(new SqlParameter("AppealOrRevisionFilingDate", AppealOrRevisionFilingDate));
            cmnd.Parameters.Add(new SqlParameter("AppealCourtName", AppealCourtName));
            cmnd.Parameters.Add(new SqlParameter("plaintFilingDate", plaintFilingDate));
            cmnd.Parameters.Add(new SqlParameter("AdvocateName", AdvocateName));
            cmnd.Parameters.Add(new SqlParameter("DocumentHandoverDate", DocumentHandoverDate));
            cmnd.Parameters.Add(new SqlParameter("DocumentHandoverList", DocumentHandoverList));
            cmnd.Parameters.Add(new SqlParameter("CourtSubmittedDocumentNote", CourtSubmittedDocumentNote));
            cmnd.Parameters.Add(new SqlParameter("NextAppealDate", NextAppealDate));
            cmnd.Parameters.Add(new SqlParameter("NextAppealReason", NextAppealReason));
            cmnd.Parameters.Add(new SqlParameter("AppealOrRevisionResult", AppealOrRevisionResult));
            cmnd.Parameters.Add(new SqlParameter("Remark", Remark));

            cmnd.ExecuteNonQuery();
            cmnd.Parameters.Clear();
            trans.Commit();

            return LandCaseId;
        }
        catch (Exception ee)
        {
            trans.Rollback();
            throw ee;

        }
        finally
        {
            objhdcon.CloseConnection();
        }
    }
}



