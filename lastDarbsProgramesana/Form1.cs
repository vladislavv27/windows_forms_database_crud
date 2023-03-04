using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace lastDarbsProgramesana
{
    public partial class Form1 : Form
    {
        public NpgsqlConnection con;
        public NpgsqlConnection conn;

        NpgsqlDataAdapter adapter_persona = new NpgsqlDataAdapter();
        NpgsqlDataAdapter adapter_izglitiba = new NpgsqlDataAdapter();
        NpgsqlDataAdapter adapter_dzimums = new NpgsqlDataAdapter();
        NpgsqlDataAdapter adapter_vecuma_grupa = new NpgsqlDataAdapter();
        NpgsqlDataAdapter adapter_nacionalitate = new NpgsqlDataAdapter();
        NpgsqlDataAdapter adapter_deklareta_dzivesvieta = new NpgsqlDataAdapter();
        NpgsqlDataAdapter adapter_pilsoniba = new NpgsqlDataAdapter();
        NpgsqlDataAdapter adapter_invaliditate = new NpgsqlDataAdapter();
        NpgsqlDataAdapter adapter_profesija = new NpgsqlDataAdapter();






        public NpgsqlDataAdapter nacionalitateadap;
        public NpgsqlDataAdapter nacionalitateadap1 = new NpgsqlDataAdapter();
        NpgsqlDataAdapter deklareta_dzivesvietaAdap;
        public DataTable nacionalitate;
        public int rowIndex;
        DataTable deklareta_dzivesvieta1;
        public int cur_node;

        //nacionalitate=kategotijas

        //deklareta_dzivesvieta=preces
        public int a;




        public Form1()
        {
           
            InitializeComponent();
            con = new NpgsqlConnection("Host=localhost;Port=5432;Username=students;Password=students;Database=test1");


            treeView1.LabelEdit = true;
            nacionalitate = new DataTable();
            deklareta_dzivesvieta1 = new DataTable();
            dataGridView10.DataSource = deklareta_dzivesvieta1;
            SubLevel(0, null);

            #region select

            NpgsqlCommand select_dzimums = new NpgsqlCommand("SELECT * FROM dzimums", con);

            NpgsqlCommand update_dzimums = new NpgsqlCommand("UPDATE dzimums SET kods=:kods,nosaukums=:nosaukums WHERE dzimums_id=:dzimums_id", con);
            update_dzimums.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));
            update_dzimums.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));


            NpgsqlCommand insert_dzimums = new NpgsqlCommand("INSERT INTO dzimums(kods,nosaukums) VALUES(:kods,:nosaukums)", con);
            insert_dzimums.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));
            insert_dzimums.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));

            NpgsqlCommand delete_dzimums = new NpgsqlCommand("DELETE FROM dzimums WHERE dzimums_id=:dzimums_id", con);
            delete_dzimums.Parameters.Add(new NpgsqlParameter("@dzimums_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "dzimums_id"));

            
            adapter_dzimums.SelectCommand = select_dzimums;
            adapter_dzimums.InsertCommand = insert_dzimums;
            adapter_dzimums.UpdateCommand = update_dzimums;
            adapter_dzimums.DeleteCommand = delete_dzimums;

            NpgsqlCommand select_vecuma_grupa = new NpgsqlCommand("SELECT * FROM vecuma_grupa", con);

            NpgsqlCommand update_vecuma_grupa = new NpgsqlCommand("UPDATE vecuma_grupa SET vecums_no=:vecums_no,vecums_lidz=:vecums_lidz,kods=:kods,nosaukums=:nosaukums WHERE vecuma_grupa_id=:vecuma_grupa_id", con);
            update_vecuma_grupa.Parameters.Add(new NpgsqlParameter("@vecuma_grupa_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "vecuma_grupa_id"));
            update_vecuma_grupa.Parameters.Add(new NpgsqlParameter("@vecums_no", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "vecums_no"));
            update_vecuma_grupa.Parameters.Add(new NpgsqlParameter("@vecums_lidz", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "vecums_lidz"));
            update_vecuma_grupa.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));
            update_vecuma_grupa.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));

            NpgsqlCommand insert_vecuma_grupa = new NpgsqlCommand("INSERT INTO vecuma_grupa(vecums_no,vecums_lidz,kods,nosaukums) VALUES(:vecums_no,:vecums_lidz,:kods,:nosaukums)", con);
            insert_vecuma_grupa.Parameters.Add(new NpgsqlParameter("@vecums_no", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "vecums_no"));
            insert_vecuma_grupa.Parameters.Add(new NpgsqlParameter("@vecums_lidz", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "vecums_lidz"));
            insert_vecuma_grupa.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));
            insert_vecuma_grupa.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));
            NpgsqlCommand delete_vecuma_grupa = new NpgsqlCommand("DELETE FROM vecuma_grupa WHERE vecuma_grupa_id=:vecuma_grupa_id", con);
            delete_vecuma_grupa.Parameters.Add(new NpgsqlParameter("@vecuma_grupa_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "vecuma_grupa_id"));

            adapter_vecuma_grupa.SelectCommand = select_vecuma_grupa;
            adapter_vecuma_grupa.InsertCommand = insert_vecuma_grupa;
            adapter_vecuma_grupa.UpdateCommand = update_vecuma_grupa;
            adapter_vecuma_grupa.DeleteCommand = delete_vecuma_grupa;



            NpgsqlCommand select_nacionalitate = new NpgsqlCommand("SELECT * FROM nacionalitate", con);

            NpgsqlCommand update_nacionalitate = new NpgsqlCommand("UPDATE nacionalitate SET kods=:kods,nosaukums=:nosaukums,nacdzivesvieta_id=:nacdzivesvieta_id WHERE nacionalitate_id=:nacionalitate_id", con);
            update_nacionalitate.Parameters.Add(new NpgsqlParameter("@nacionalitate_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "nacionalitate_id"));
            update_nacionalitate.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));
            update_nacionalitate.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));
            update_nacionalitate.Parameters.Add(new NpgsqlParameter("@nacdzivesvieta_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "nacdzivesvieta_id"));

            
            NpgsqlCommand insert_nacionalitate = new NpgsqlCommand("INSERT INTO nacionalitate(kods,nosaukums,nacdzivesvieta_id) VALUES(:kods,:nosaukums,:nacdzivesvieta_id)", con);
            insert_nacionalitate.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));
            insert_nacionalitate.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));
            insert_nacionalitate.Parameters.Add(new NpgsqlParameter("@nacdzivesvieta_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "nacdzivesvieta_id"));

            NpgsqlCommand delete_nacionalitate = new NpgsqlCommand("DELETE FROM nacionalitate WHERE nacionalitate_id=:nacionalitate_id", con);
            delete_nacionalitate.Parameters.Add(new NpgsqlParameter("@nacionalitate_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "nacionalitate_id"));

            adapter_nacionalitate.SelectCommand = select_nacionalitate;
            adapter_nacionalitate.InsertCommand = insert_nacionalitate;
            adapter_nacionalitate.UpdateCommand = update_nacionalitate;
            adapter_nacionalitate.DeleteCommand = delete_nacionalitate;



            NpgsqlCommand select_deklareta_dzivesvieta = new NpgsqlCommand("SELECT * FROM deklareta_dzivesvieta", con);

            NpgsqlCommand update_deklareta_dzivesvieta = new NpgsqlCommand("UPDATE deklareta_dzivesvieta SET valsts=:valsts,regions=:regions,pilseta=:pilseta,iela=:iela,majas_numurs=:majas_numurs,dzivokla_numurs=:dzivokla_numurs WHERE deklareta_dzivesvieta_id=:deklareta_dzivesvieta_id,dzivesvieta_id=:dzivesvieta_id", con);
            update_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@valsts", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "valsts"));
            update_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@regions", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "regions"));
            update_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@pilseta", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "pilseta"));
            update_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@iela", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "iela"));
            update_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@majas_numurs", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "majas_numurs"));
            update_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@dzivokla_numurs", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "dzivokla_numurs"));
            update_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@dzivesvieta_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "dzivesvieta_id"));

            NpgsqlCommand insert_deklareta_dzivesvieta = new NpgsqlCommand("INSERT INTO deklareta_dzivesvieta(valsts,regions,pilseta,iela,majas_numurs,dzivokla_numurs,dzivesvieta_id) VALUES(:valsts,:regions,:pilseta,:iela,:majas_numurs,:dzivokla_numurs,:dzivesvieta_id)", con);
            insert_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@valsts", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "valsts"));
            insert_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@regions", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "regions"));
            insert_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@pilseta", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "pilseta"));
            insert_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@iela", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "iela"));
            insert_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@majas_numurs", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "majas_numurs"));
            insert_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@dzivokla_numurs", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "dzivokla_numurs"));
            insert_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@dzivesvieta_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "dzivesvieta_id"));

            NpgsqlCommand delete_deklareta_dzivesvieta = new NpgsqlCommand("DELETE FROM deklareta_dzivesvieta WHERE deklareta_dzivesvieta_id=:deklareta_dzivesvieta_id", con);
            delete_deklareta_dzivesvieta.Parameters.Add(new NpgsqlParameter("@deklareta_dzivesvieta_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "deklareta_dzivesvieta_id"));

            adapter_deklareta_dzivesvieta.SelectCommand = select_deklareta_dzivesvieta;
            adapter_deklareta_dzivesvieta.InsertCommand = insert_deklareta_dzivesvieta;
            adapter_deklareta_dzivesvieta.UpdateCommand = update_deklareta_dzivesvieta;
            adapter_deklareta_dzivesvieta.DeleteCommand = delete_deklareta_dzivesvieta;



            NpgsqlCommand select_pilsoniba = new NpgsqlCommand("SELECT * FROM pilsoniba", con);

            NpgsqlCommand update_pilsoniba = new NpgsqlCommand("UPDATE pilsoniba SET nosaukums=:nosaukums,kods=:kods where pilsoniba_id=:pilsoniba_id", con);
            update_pilsoniba.Parameters.Add(new NpgsqlParameter("@pilsoniba_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "pilsoniba_id"));
            update_pilsoniba.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));
            update_pilsoniba.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));

            NpgsqlCommand insert_pilsoniba = new NpgsqlCommand("INSERT INTO pilsoniba(nosaukums,kods) VALUES(:nosaukums,:kods)", con);
            insert_pilsoniba.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));
            insert_pilsoniba.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));

            NpgsqlCommand delete_pilsoniba = new NpgsqlCommand("DELETE FROM pilsoniba WHERE pilsoniba_id=:pilsoniba_id", con);
            delete_pilsoniba.Parameters.Add(new NpgsqlParameter("@pilsoniba_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "pilsoniba_id"));


            adapter_pilsoniba.SelectCommand = select_pilsoniba;
            adapter_pilsoniba.InsertCommand = insert_pilsoniba;
            adapter_pilsoniba.UpdateCommand = update_pilsoniba;
            adapter_pilsoniba.DeleteCommand = delete_pilsoniba;




            NpgsqlCommand select_invaliditate = new NpgsqlCommand("SELECT * FROM invaliditate", con);

            NpgsqlCommand update_invaliditate = new NpgsqlCommand("UPDATE invaliditate SET nosaukums=:nosaukums,kods=:kods WHERE invaliditate_id=:invaliditate_id", con);
            update_invaliditate.Parameters.Add(new NpgsqlParameter("@invaliditate_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "invaliditate_id"));
            update_invaliditate.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));
            update_invaliditate.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));

            NpgsqlCommand insert_invaliditate = new NpgsqlCommand("INSERT INTO invaliditate(nosaukums,kods) VALUES(:nosaukums,:kods)", con);
            insert_invaliditate.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));
            insert_invaliditate.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));

            NpgsqlCommand delete_invaliditate = new NpgsqlCommand("DELETE FROM invaliditate WHERE invaliditate_id=:invaliditate_id", con);
            delete_invaliditate.Parameters.Add(new NpgsqlParameter("@invaliditate_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "invaliditate_id"));

            adapter_invaliditate.SelectCommand = select_invaliditate;
            adapter_invaliditate.InsertCommand = insert_invaliditate;
            adapter_invaliditate.UpdateCommand = update_invaliditate;
            adapter_invaliditate.DeleteCommand = delete_invaliditate;



            NpgsqlCommand select_profesija = new NpgsqlCommand("SELECT * FROM profesija", con);

            NpgsqlCommand update_profesija = new NpgsqlCommand("UPDATE profesija SET nosaukums=:nosaukums,kods=:kods,profesijas_grupa1=:profesijas_grupa1,profesijas_grupa2=:profesijas_grupa2 WHERE profesija_id=:profesija_id", con);
            update_profesija.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));
            update_profesija.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));
            update_profesija.Parameters.Add(new NpgsqlParameter("@profesijas_grupa1", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "profesijas_grupa1"));
            update_profesija.Parameters.Add(new NpgsqlParameter("@profesijas_grupa2", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "profesijas_grupa2"));

            NpgsqlCommand insert_profesija = new NpgsqlCommand("INSERT INTO profesija(nosaukums,kods,profesijas_grupa1,profesijas_grupa2) VALUES(:nosaukums,:kods,:profesijas_grupa1,:profesijas_grupa2)", con);
            insert_profesija.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));
            insert_profesija.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));
            insert_profesija.Parameters.Add(new NpgsqlParameter("@profesijas_grupa1", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "profesijas_grupa1"));
            insert_profesija.Parameters.Add(new NpgsqlParameter("@profesijas_grupa2", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "profesijas_grupa2"));

            NpgsqlCommand delete_profesija = new NpgsqlCommand("DELETE FROM profesija WHERE profesija_id=:profesija_id", con);
            delete_profesija.Parameters.Add(new NpgsqlParameter("@profesija_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "invaliditate_id"));

            adapter_profesija.SelectCommand = select_profesija;
            adapter_profesija.InsertCommand = insert_profesija;
            adapter_profesija.UpdateCommand = update_profesija;
            adapter_profesija.DeleteCommand = delete_profesija;



            NpgsqlCommand select_izglitiba = new NpgsqlCommand("SELECT * FROM izglitiba", con);

            NpgsqlCommand update_izglitiba = new NpgsqlCommand("UPDATE izglitiba SET nosaukums=:nosaukums,kods=:kods,izglitibas_limena_grupa=:izglitibas_limena_grupa,izglitibas_veids=:izglitibas_veids,dokumenta_veids=:dokumenta_veids,dokumenta_izsneigsanas_datums=:dokumenta_izsneigsanas_datums where izglitiba_id=:izglitiba_id", con);
            update_izglitiba.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));
            update_izglitiba.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));
            update_izglitiba.Parameters.Add(new NpgsqlParameter("@izglitibas_limena_grupa", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "izglitibas_limena_grupa"));
            update_izglitiba.Parameters.Add(new NpgsqlParameter("@izglitibas_veids", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "izglitibas_veids"));
            update_izglitiba.Parameters.Add(new NpgsqlParameter("@dokumenta_veids", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "dokumenta_veids"));
            update_izglitiba.Parameters.Add(new NpgsqlParameter("@dokumenta_izsneigsanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 255, "dokumenta_izsneigsanas_datums"));

            NpgsqlCommand insert_izglitiba = new NpgsqlCommand("INSERT INTO izglitiba(nosaukums,kods,izglitibas_limena_grupa,izglitibas_veids,dokumenta_veids,dokumenta_izsneigsanas_datums) VALUES(:nosaukums,:kods,:izglitibas_limena_grupa,:izglitibas_veids,:dokumenta_veids,:dokumenta_izsneigsanas_datums)", con);
            insert_izglitiba.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));
            insert_izglitiba.Parameters.Add(new NpgsqlParameter("@kods", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "kods"));
            insert_izglitiba.Parameters.Add(new NpgsqlParameter("@izglitibas_limena_grupa", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "izglitibas_limena_grupa"));
            insert_izglitiba.Parameters.Add(new NpgsqlParameter("@izglitibas_veids", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "izglitibas_veids"));
            insert_izglitiba.Parameters.Add(new NpgsqlParameter("@dokumenta_veids", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "dokumenta_veids"));
            insert_izglitiba.Parameters.Add(new NpgsqlParameter("@dokumenta_izsneigsanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 255, "dokumenta_izsneigsanas_datums"));

            NpgsqlCommand delete_izglitiba = new NpgsqlCommand("DELETE FROM izglitiba WHERE izglitiba_id=:izglitiba_id", con);
            delete_izglitiba.Parameters.Add(new NpgsqlParameter("@izglitiba_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "izglitiba_id"));



            adapter_izglitiba.SelectCommand = select_izglitiba;
            adapter_izglitiba.InsertCommand = insert_izglitiba;
            adapter_izglitiba.UpdateCommand = update_izglitiba;
            adapter_izglitiba.DeleteCommand = delete_izglitiba;



            NpgsqlCommand select_persona = new NpgsqlCommand("SELECT * FROM persona", con);

            NpgsqlCommand insert_persona = new NpgsqlCommand("INSERT INTO persona(vards,uzvards,dzimsanas_datums,mirsanas_datums,id_dzimums,id_vecuma_grupa,id_nacionalitate,id_deklareta_dzivesvieta,id_pilsoniba,id_invaliditate,id_profesija,id_izglitiba) VALUES(:vards,:uzvards,:dzimsanas_datums,:mirsanas_datums,:id_dzimums,:id_vecuma_grupa,:id_nacionalitate,:id_deklareta_dzivesvieta,:id_pilsoniba,:id_invaliditate,:id_profesija,:id_izglitiba) ", con);

            insert_persona.Parameters.Add(new NpgsqlParameter("@vards", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "vards"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@uzvards", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "uzvards"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@dzimsanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 255, "dzimsanas_datums"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@mirsanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 255, "mirsanas_datums"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@id_dzimums", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_dzimums"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@id_vecuma_grupa", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_vecuma_grupa"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@id_nacionalitate", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_nacionalitate"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@id_deklareta_dzivesvieta", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_deklareta_dzivesvieta"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@id_pilsoniba", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_pilsoniba"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@id_invaliditate", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_invaliditate"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@id_profesija", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_profesija"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@id_izglitiba", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_izglitiba"));
           


            NpgsqlCommand update_persona = new NpgsqlCommand("UPDATE persona SET vards=:vards,uzvards=:uzvards,dzimsanas_datums=:dzimsanas_datums,mirsanas_datums=:mirsanas_datums,id_dzimums=:id_dzimums,id_vecuma_grupa=:id_vecuma_grupa,id_nacionalitate=:id_nacionalitate,id_deklareta_dzivesvieta=:id_deklareta_dzivesvieta,id_pilsoniba=:id_pilsoniba,id_invaliditate=:id_invaliditate,id_profesija=:id_profesija,id_izglitiba=:id_izglitiba WHERE persona_id=:persona_id", con);
            update_persona.Parameters.Add(new NpgsqlParameter("@vards", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "vards"));
            update_persona.Parameters.Add(new NpgsqlParameter("@uzvards", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "uzvards"));
            update_persona.Parameters.Add(new NpgsqlParameter("@dzimsanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 255, "dzimsanas_datums"));
            update_persona.Parameters.Add(new NpgsqlParameter("@mirsanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 255, "mirsanas_datums"));
            update_persona.Parameters.Add(new NpgsqlParameter("@id_dzimums", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_dzimums"));
            update_persona.Parameters.Add(new NpgsqlParameter("@id_vecuma_grupa", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_vecuma_grupa"));
            update_persona.Parameters.Add(new NpgsqlParameter("@id_nacionalitate", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_nacionalitate"));
            update_persona.Parameters.Add(new NpgsqlParameter("@id_deklareta_dzivesvieta", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_deklareta_dzivesvieta"));
            update_persona.Parameters.Add(new NpgsqlParameter("@id_pilsoniba", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_pilsoniba"));
            update_persona.Parameters.Add(new NpgsqlParameter("@id_invaliditate", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_invaliditate"));
            update_persona.Parameters.Add(new NpgsqlParameter("@id_profesija", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_profesija"));
            update_persona.Parameters.Add(new NpgsqlParameter("@id_izglitiba", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_izglitiba"));
            update_persona.Parameters.Add(new NpgsqlParameter("@persona_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "persona_id"));


            NpgsqlCommand delete_persona = new NpgsqlCommand("DELETE FROM persona WHERE persona_id=:persona_id ", con);
            delete_persona.Parameters.Add(new NpgsqlParameter("@persona_id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "persona_id"));
            adapter_persona.SelectCommand = select_persona;
            adapter_persona.InsertCommand = insert_persona;
            adapter_persona.UpdateCommand = update_persona;
            adapter_persona.DeleteCommand = delete_persona;
            #endregion



        }
        #region treevie
        public void SubLevel(int parentid, TreeNode parentNode)
        {
            NpgsqlCommand sel3 = new NpgsqlCommand("SELECT nacionalitate_id, nosaukums FROM nacionalitate WHERE nacdzivesvieta_id = @nacionalitate_id", con);
            sel3.Parameters.Add("@nacionalitate_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = parentid;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sel3);
            DataTable dta = new DataTable();
            da.Fill(dta);
            if (parentid == 0)
            {
                CreateNodes(dta, treeView1.Nodes);
            }
            else
                CreateNodes(dta, parentNode.Nodes);
        }
        public void dgva_select(int e)
        {
            if (e.ToString() != "")
            {
                deklareta_dzivesvieta1 = new DataTable();
                deklareta_dzivesvietaAdap = new NpgsqlDataAdapter();
                NpgsqlCommand pr2 = new NpgsqlCommand("Select * from deklareta_dzivesvieta WHERE dzivesvieta_id=@nacdzivesvieta_id", con);
                pr2.Parameters.Add("nacdzivesvieta_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = e;
                deklareta_dzivesvietaAdap.SelectCommand = pr2;
                deklareta_dzivesvietaAdap.Fill(deklareta_dzivesvieta1);
                dataGridView10.DataSource = deklareta_dzivesvieta1;
            }
            NpgsqlCommand selectapraksts = new NpgsqlCommand("Select nacionalitate_id,nosaukums from nacionalitate", con);
            cur_node = e;
        }
       

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int y = 0;
            if (e.Node.Name != "")
                y = Convert.ToInt32(e.Node.Name);
            dgva_select(y);
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name != "")
            {
                TreeNode tn = new TreeNode();
                tn.Text = "new";
                e.Node.Nodes.Add(tn);
            }
        }
   
        public void CreateNodes(DataTable dta, TreeNodeCollection nodes)
        {
            foreach (DataRow dr1 in dta.Rows)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr1["nosaukums"].ToString();
                tn.Name = dr1["nacionalitate_id"].ToString();
                nodes.Add(tn);
                SubLevel(Convert.ToInt32(tn.Name), tn);

            }
        }
        #endregion  

        DataSet ds = new DataSet();
        DataTable dtpersona = new DataTable();
        DataTable dtdzimums = new DataTable();
        DataTable dtvecuma_grupa = new DataTable();
        DataTable dtnacionalitate = new DataTable();
        DataTable dtdeklareta_dzivesvieta = new DataTable();
        DataTable dtpilsoniba = new DataTable();
        DataTable dtinvaliditate = new DataTable();
        DataTable dtprofesija = new DataTable();
        DataTable dtizglitiba = new DataTable();


        private void button1_Click(object sender, EventArgs e)
        {
             ds = new DataSet();
            dtpersona = new DataTable();
             dtdzimums = new DataTable();
             dtvecuma_grupa = new DataTable();
             dtnacionalitate = new DataTable();
             dtdeklareta_dzivesvieta = new DataTable();
             dtpilsoniba = new DataTable();
             dtinvaliditate = new DataTable();
             dtprofesija = new DataTable();
             dtizglitiba = new DataTable();
            a = 1;
            #region COMBO
            ds.Tables.Add(dtpersona);
            ds.Tables.Add(dtdzimums);
            ds.Tables.Add(dtvecuma_grupa);
            ds.Tables.Add(dtnacionalitate);
            ds.Tables.Add(dtdeklareta_dzivesvieta);
            ds.Tables.Add(dtpilsoniba);
            ds.Tables.Add(dtinvaliditate);
            ds.Tables.Add(dtprofesija);
            ds.Tables.Add(dtizglitiba);
            adapter_persona.Fill(dtpersona);
            adapter_dzimums.Fill(dtdzimums);
            adapter_vecuma_grupa.Fill(dtvecuma_grupa);
            adapter_nacionalitate.Fill(dtnacionalitate);
            adapter_deklareta_dzivesvieta.Fill(dtdeklareta_dzivesvieta);
            adapter_pilsoniba.Fill(dtpilsoniba);
            adapter_invaliditate.Fill(dtinvaliditate);
            adapter_profesija.Fill(dtprofesija);
            adapter_izglitiba.Fill(dtizglitiba);


            ds.Relations.Add(new DataRelation("persona_dzimums", dtdzimums.Columns["dzimums_id"], dtpersona.Columns["id_dzimums"], true));

            //ds.Relations.Add(new DataRelation("persona_vecuma_grupa", dtvecuma_grupa.Columns["vecuma_grupa_id"], dtpersona.Columns["id_vecuma_grupa"], true));

            //ds.Relations.Add(new DataRelation("persona_nacionalitate", dtnacionalitate.Columns["nacionalitate_id"], dtpersona.Columns["id_nacionalitate"], true));

            //ds.Relations.Add(new DataRelation("persona_deklareta_dzivesvieta", dtdeklareta_dzivesvieta.Columns["deklareta_dzivesvieta_id"], dtpersona.Columns["id_deklareta_dzivesvieta"], true));

            //ds.Relations.Add(new DataRelation("persona_pilsoniba", dtpilsoniba.Columns["pilsoniba_id"], dtpersona.Columns["id_pilsoniba"], true));

            //ds.Relations.Add(new DataRelation("persona_invaliditate", dtinvaliditate.Columns["invaliditate_id"], dtpersona.Columns["id_invaliditate"], true));

            //ds.Relations.Add(new DataRelation("persona_profesija",  dtprofesija.Columns["profesija_id"], dtpersona.Columns["id_profesija"], true));

            //ds.Relations.Add(new DataRelation("persona_izglitiba", dtizglitiba.Columns["izglitiba_id"], dtpersona.Columns["id_profesija"], true));


            dataGridView1.DataSource = dtpersona;
            dataGridView1.DataSource = dtdzimums;
            dataGridView2.DataSource = dtdzimums;
            dataGridView2.Columns["dzimums_id"].Visible = false;
            dataGridView2.Columns["kods"].Visible = false;
            dataGridView1.DataMember = "persona_dzimums";
            dataGridView1.Columns["persona_id"].Visible = false;
            dataGridView1.Columns["id_dzimums"].Visible = false;
            dataGridView1.Columns["id_vecuma_grupa"].Visible = false;
            dataGridView1.Columns["id_nacionalitate"].Visible = false;
            dataGridView1.Columns["id_deklareta_dzivesvieta"].Visible = false;
            dataGridView1.Columns["id_pilsoniba"].Visible = false;
            dataGridView1.Columns["id_invaliditate"].Visible = false;
            dataGridView1.Columns["id_profesija"].Visible = false;
            dataGridView1.Columns["id_izglitiba"].Visible = false;


           

            DataGridViewComboBoxColumn comboCol1 = new DataGridViewComboBoxColumn();
            comboCol1.DataSource = dtdzimums;
            comboCol1.HeaderText = "dzimums";
            comboCol1.ValueMember = "dzimums_id"; 
            comboCol1.DisplayMember = "nosaukums";  
            comboCol1.DataPropertyName = "id_dzimums";

            dataGridView1.Columns.Add(comboCol1);

            comboBox1.ValueMember = "dzimums_id";
            comboBox1.DataSource = dtdzimums;
            comboBox1.DisplayMember = "nosaukums";

            DataGridViewComboBoxColumn comboCol2 = new DataGridViewComboBoxColumn();
            comboCol2.DataSource = dtvecuma_grupa;
            comboCol2.HeaderText = "vecuma grupa";
            comboCol2.ValueMember = "vecuma_grupa_id"; 
            comboCol2.DisplayMember = "nosaukums";  
            comboCol2.DataPropertyName = "id_vecuma_grupa";
            dataGridView1.Columns.Add(comboCol2);
            comboBox2.ValueMember = "vecuma_grupa_id";
            comboBox2.DataSource = dtvecuma_grupa;
            comboBox2.DisplayMember = "nosaukums";
            DataGridViewComboBoxColumn comboCol3 = new DataGridViewComboBoxColumn();
            comboCol3.DataSource = dtnacionalitate;
            comboCol3.HeaderText = "nacionalitate";
            comboCol3.ValueMember = "nacionalitate_id"; 
            comboCol3.DisplayMember = "nosaukums";  
            comboCol3.DataPropertyName = "id_nacionalitate";
            dataGridView1.Columns.Add(comboCol3);

            comboBox3.DataSource = dtnacionalitate;
            comboBox3.ValueMember = "nacionalitate_id";         
            comboBox3.DisplayMember = "nosaukums";

            DataGridViewComboBoxColumn comboCol4 = new DataGridViewComboBoxColumn();
            comboCol4.DataSource = dtdeklareta_dzivesvieta;
            comboCol4.HeaderText = "deklareta dzivesvieta";
            comboCol4.ValueMember = "deklareta_dzivesvieta_id"; 
            comboCol4.DisplayMember = "pilseta";  
            comboCol4.DataPropertyName = "id_deklareta_dzivesvieta";
            dataGridView1.Columns.Add(comboCol4);

            comboBox4.DataSource = dtdeklareta_dzivesvieta;
            comboBox4.ValueMember = "deklareta_dzivesvieta_id";
            comboBox4.DisplayMember = "pilseta";

            DataGridViewComboBoxColumn comboCol5 = new DataGridViewComboBoxColumn();
            comboCol5.DataSource = dtpilsoniba;
            comboCol5.HeaderText = "pilsoniba";
            comboCol5.ValueMember = "pilsoniba_id"; 
            comboCol5.DisplayMember = "nosaukums";  
            comboCol5.DataPropertyName = "id_pilsoniba";
            dataGridView1.Columns.Add(comboCol5);

            comboBox5.DataSource = dtpilsoniba;
            comboBox5.ValueMember = "pilsoniba_id";
            comboBox5.DisplayMember = "nosaukums";

            DataGridViewComboBoxColumn comboCol6 = new DataGridViewComboBoxColumn();
            comboCol6.DataSource = dtinvaliditate;
            comboCol6.HeaderText = "invaliditate";
            comboCol6.ValueMember = "invaliditate_id"; 
            comboCol6.DisplayMember = "nosaukums";  
            comboCol6.DataPropertyName = "id_invaliditate";
            dataGridView1.Columns.Add(comboCol6);

            comboBox6.DataSource = dtinvaliditate;
            comboBox6.ValueMember = "invaliditate_id";
            comboBox6.DisplayMember = "nosaukums";

            DataGridViewComboBoxColumn comboCol7 = new DataGridViewComboBoxColumn();
            comboCol7.DataSource = dtprofesija;
            comboCol7.HeaderText = "profesija";
            comboCol7.ValueMember = "profesija_id"; 
            comboCol7.DisplayMember = "nosaukums";  
            comboCol7.DataPropertyName = "id_profesija";
            dataGridView1.Columns.Add(comboCol7);

            comboBox7.DataSource = dtprofesija;
            comboBox7.ValueMember = "profesija_id";
            comboBox7.DisplayMember = "nosaukums";

            DataGridViewComboBoxColumn comboCol8 = new DataGridViewComboBoxColumn();
            comboCol8.DataSource = dtizglitiba;
            comboCol8.HeaderText = "izglitiba";
            comboCol8.ValueMember = "izglitiba_id"; 
            comboCol8.DisplayMember = "nosaukums";  
            comboCol8.DataPropertyName = "id_izglitiba";
            dataGridView1.Columns.Add(comboCol8);

            comboBox8.DataSource = dtizglitiba;
            comboBox8.ValueMember = "izglitiba_id";
            comboBox8.DisplayMember = "nosaukums";

            dataGridView3.DataSource = dtizglitiba;

            dataGridView9.DataSource = dtnacionalitate;
            dataGridView5.DataSource = dtdeklareta_dzivesvieta;
            dataGridView6.DataSource = dtpilsoniba;
            dataGridView7.DataSource = dtinvaliditate;
            dataGridView8.DataSource = dtprofesija;
            dataGridView4.DataSource = dtvecuma_grupa;
            dataGridView3.Columns["izglitiba_id"].Visible = false;
            dataGridView4.Columns["vecuma_grupa_id"].Visible = false;
            dataGridView5.Columns["deklareta_dzivesvieta_id"].Visible = false;
            dataGridView6.Columns["pilsoniba_id"].Visible = false;
            dataGridView7.Columns["invaliditate_id"].Visible = false;
            dataGridView8.Columns["profesija_id"].Visible = false;
            dataGridView9.Columns["nacionalitate_id"].Visible = false;
            #endregion
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            adapter_persona.Update(dtpersona);
            adapter_dzimums.Update(dtdzimums);
            adapter_vecuma_grupa.Update(dtvecuma_grupa);
            adapter_nacionalitate.Update(dtnacionalitate);
            adapter_deklareta_dzivesvieta.Update(dtdeklareta_dzivesvieta);
            adapter_pilsoniba.Update(dtpilsoniba);
            adapter_invaliditate.Update(dtinvaliditate);
            adapter_profesija.Update(dtprofesija);
            adapter_izglitiba.Update(dtizglitiba);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
     

            conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=students;Password=students;Database=test1");
            NpgsqlDataAdapter personaadd = new NpgsqlDataAdapter();
            NpgsqlDataAdapter profesijadd = new NpgsqlDataAdapter();
           
            


                  NpgsqlCommand cmd2 = new NpgsqlCommand("INSERT INTO profesija(nosaukums,kods,profesijas_grupa1,profesijas_grupa2) VALUES(:nosaukums,:kods,:profesijas_grupa1,:profesijas_grupa2) returning profesija_id", conn);
                
                cmd2.Parameters.Add(new NpgsqlParameter("nosaukums", textBox14.Text));
                cmd2.Parameters.Add(new NpgsqlParameter("kods", Convert.ToInt32(this.textBox15.Text)));
                cmd2.Parameters.Add(new NpgsqlParameter("profesijas_grupa1", textBox16.Text));
                cmd2.Parameters.Add(new NpgsqlParameter("profesijas_grupa2", textBox17.Text));

                    profesijadd.InsertCommand = cmd2;
            
                conn.Open();
                var id = cmd2.ExecuteScalar();
                conn.Close();

            NpgsqlCommand cmd1 = new NpgsqlCommand("insert into persona(vards,uzvards,dzimsanas_datums,mirsanas_datums,id_dzimums,id_vecuma_grupa,id_nacionalitate,id_deklareta_dzivesvieta,id_pilsoniba,id_invaliditate,id_profesija,id_izglitiba) VALUES(:vards,:uzvards,:dzimsanas_datums,:mirsanas_datums,:id_dzimums,:id_vecuma_grupa,:id_nacionalitate,:id_deklareta_dzivesvieta,:id_pilsoniba,:id_invaliditate,:id_profesija,:id_izglitiba) ", conn);
            object dateTimeValue = textBox4.Text;

            if (String.IsNullOrEmpty(textBox4.Text))
            {
                dateTimeValue = DBNull.Value;
            }
            else
            {
                dateTimeValue = Convert.ToDateTime(this.textBox4.Text);
            }
            personaadd.InsertCommand = cmd1;
            cmd1.Parameters.Add(new NpgsqlParameter("vards", textBox1.Text));
            cmd1.Parameters.Add(new NpgsqlParameter("uzvards", textBox2.Text));
            cmd1.Parameters.Add(new NpgsqlParameter("@dzimsanas_datums", Convert.ToDateTime(this.textBox3.Text)));
            cmd1.Parameters.Add(new NpgsqlParameter("@mirsanas_datums", dateTimeValue));
            cmd1.Parameters.Add(new NpgsqlParameter("id_dzimums", comboBox1.SelectedValue));
            cmd1.Parameters.Add(new NpgsqlParameter("id_vecuma_grupa", comboBox2.SelectedValue));
            cmd1.Parameters.Add(new NpgsqlParameter("id_nacionalitate", comboBox3.SelectedValue));
            cmd1.Parameters.Add(new NpgsqlParameter("id_deklareta_dzivesvieta", comboBox4.SelectedValue));
            cmd1.Parameters.Add(new NpgsqlParameter("id_pilsoniba", comboBox5.SelectedValue));
            cmd1.Parameters.Add(new NpgsqlParameter("id_invaliditate", comboBox6.SelectedValue));
            cmd1.Parameters.Add(new NpgsqlParameter("id_profesija", id));
            cmd1.Parameters.Add(new NpgsqlParameter("id_izglitiba", comboBox8.SelectedValue));
            conn.Open();
            cmd1.ExecuteScalar();
            conn.Close();





        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = dtpersona;
            dtpersona.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "vards", textBox13.Text);
            #region combo2
            //if (a==1)
            //{
            //    DataGridViewComboBoxColumn comboCol1 = new DataGridViewComboBoxColumn();
            //    comboCol1.DataSource = dtdzimums;
            //    comboCol1.HeaderText = "dzimums";
            //    comboCol1.ValueMember = "dzimums_id"; 
            //    comboCol1.DisplayMember = "nosaukums";  
            //    comboCol1.DataPropertyName = "id_dzimums";

            //    dataGridView1.Columns.Add(comboCol1);

            //    DataGridViewComboBoxColumn comboCol2 = new DataGridViewComboBoxColumn();
            //    comboCol2.DataSource = dtvecuma_grupa;
            //    comboCol2.HeaderText = "vecuma grupa";
            //    comboCol2.ValueMember = "vecuma_grupa_id"; 
            //    comboCol2.DisplayMember = "nosaukums";  
            //    comboCol2.DataPropertyName = "id_vecuma_grupa";
            //    dataGridView1.Columns.Add(comboCol2);

            //    DataGridViewComboBoxColumn comboCol3 = new DataGridViewComboBoxColumn();
            //    comboCol3.DataSource = dtnacionalitate;
            //    comboCol3.HeaderText = "nacionalitate";
            //    comboCol3.ValueMember = "nacionalitate_id"; 
            //    comboCol3.DisplayMember = "nosaukums";  
            //    comboCol3.DataPropertyName = "id_nacionalitate";
            //    dataGridView1.Columns.Add(comboCol3);

            //    DataGridViewComboBoxColumn comboCol4 = new DataGridViewComboBoxColumn();
            //    comboCol4.DataSource = dtdeklareta_dzivesvieta;
            //    comboCol4.HeaderText = "deklareta dzivesvieta";
            //    comboCol4.ValueMember = "deklareta_dzivesvieta_id"; 
            //    comboCol4.DisplayMember = "pilseta";  
            //    comboCol4.DataPropertyName = "id_deklareta_dzivesvieta";
            //    dataGridView1.Columns.Add(comboCol4);

            //    DataGridViewComboBoxColumn comboCol5 = new DataGridViewComboBoxColumn();
            //    comboCol5.DataSource = dtpilsoniba;
            //    comboCol5.HeaderText = "pilsoniba";
            //    comboCol5.ValueMember = "pilsoniba_id"; 
            //    comboCol5.DisplayMember = "nosaukums";  
            //    comboCol5.DataPropertyName = "id_pilsoniba";
            //    dataGridView1.Columns.Add(comboCol5);

            //    DataGridViewComboBoxColumn comboCol6 = new DataGridViewComboBoxColumn();
            //    comboCol6.DataSource = dtinvaliditate;
            //    comboCol6.HeaderText = "invaliditate";
            //    comboCol6.ValueMember = "invaliditate_id"; 
            //    comboCol6.DisplayMember = "nosaukums";  
            //    comboCol6.DataPropertyName = "id_invaliditate";
            //    dataGridView1.Columns.Add(comboCol6);

            //    DataGridViewComboBoxColumn comboCol7 = new DataGridViewComboBoxColumn();
            //    comboCol7.DataSource = dtprofesija;
            //    comboCol7.HeaderText = "profesija";
            //    comboCol7.ValueMember = "profesija_id"; 
            //    comboCol7.DisplayMember = "nosaukums";  
            //    comboCol7.DataPropertyName = "id_profesija";
            //    dataGridView1.Columns.Add(comboCol7);

            //    DataGridViewComboBoxColumn comboCol8 = new DataGridViewComboBoxColumn();
            //    comboCol8.DataSource = dtizglitiba;
            //    comboCol8.HeaderText = "izglitiba";
            //    comboCol8.ValueMember = "izglitiba_id"; 
            //    comboCol8.DisplayMember = "nosaukums";  
            //    comboCol8.DataPropertyName = "id_izglitiba";
            //    dataGridView1.Columns.Add(comboCol8);

            //    a++;
            //}


            //dataGridView1.Columns["persona_id"].Visible = false;
            //dataGridView1.Columns["id_dzimums"].Visible = false;
            //dataGridView1.Columns["id_vecuma_grupa"].Visible = false;
            //dataGridView1.Columns["id_nacionalitate"].Visible = false;
            //dataGridView1.Columns["id_deklareta_dzivesvieta"].Visible = false;
            //dataGridView1.Columns["id_pilsoniba"].Visible = false;
            //dataGridView1.Columns["id_invaliditate"].Visible = false;
            //dataGridView1.Columns["id_profesija"].Visible = false;
            //dataGridView1.Columns["id_izglitiba"].Visible = false;
            //#endregion
            #endregion
            if (a == 1)
            {
                combo();
                a++;
            }

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //22.04.2005
            dataGridView1.DataSource = dtpersona;
            dtpersona.DefaultView.RowFilter = string.Format($"convert(dzimsanas_datums, System.String) LIKE '" + textBox18.Text + "%'");
            if (a == 1)
            {
                combo();
                a++;
            }

            }
        public void combo()
        {
            #region combo2
            
                DataGridViewComboBoxColumn comboCol1 = new DataGridViewComboBoxColumn();
                comboCol1.DataSource = dtdzimums;
                comboCol1.HeaderText = "dzimums";
                comboCol1.ValueMember = "dzimums_id"; 
                comboCol1.DisplayMember = "nosaukums";  
                comboCol1.DataPropertyName = "id_dzimums";

                dataGridView1.Columns.Add(comboCol1);

                DataGridViewComboBoxColumn comboCol2 = new DataGridViewComboBoxColumn();
                comboCol2.DataSource = dtvecuma_grupa;
                comboCol2.HeaderText = "vecuma grupa";
                comboCol2.ValueMember = "vecuma_grupa_id"; 
                comboCol2.DisplayMember = "nosaukums";  
                comboCol2.DataPropertyName = "id_vecuma_grupa";
                dataGridView1.Columns.Add(comboCol2);

                DataGridViewComboBoxColumn comboCol3 = new DataGridViewComboBoxColumn();
                comboCol3.DataSource = dtnacionalitate;
                comboCol3.HeaderText = "nacionalitate";
                comboCol3.ValueMember = "nacionalitate_id"; 
                comboCol3.DisplayMember = "nosaukums";  
                comboCol3.DataPropertyName = "id_nacionalitate";
                dataGridView1.Columns.Add(comboCol3);

                DataGridViewComboBoxColumn comboCol4 = new DataGridViewComboBoxColumn();
                comboCol4.DataSource = dtdeklareta_dzivesvieta;
                comboCol4.HeaderText = "deklareta dzivesvieta";
                comboCol4.ValueMember = "deklareta_dzivesvieta_id"; 
                comboCol4.DisplayMember = "pilseta";  
                comboCol4.DataPropertyName = "id_deklareta_dzivesvieta";
                dataGridView1.Columns.Add(comboCol4);

                DataGridViewComboBoxColumn comboCol5 = new DataGridViewComboBoxColumn();
                comboCol5.DataSource = dtpilsoniba;
                comboCol5.HeaderText = "pilsoniba";
                comboCol5.ValueMember = "pilsoniba_id"; 
                comboCol5.DisplayMember = "nosaukums";  
                comboCol5.DataPropertyName = "id_pilsoniba";
                dataGridView1.Columns.Add(comboCol5);

                DataGridViewComboBoxColumn comboCol6 = new DataGridViewComboBoxColumn();
                comboCol6.DataSource = dtinvaliditate;
                comboCol6.HeaderText = "invaliditate";
                comboCol6.ValueMember = "invaliditate_id"; 
                comboCol6.DisplayMember = "nosaukums";  
                comboCol6.DataPropertyName = "id_invaliditate";
                dataGridView1.Columns.Add(comboCol6);

                DataGridViewComboBoxColumn comboCol7 = new DataGridViewComboBoxColumn();
                comboCol7.DataSource = dtprofesija;
                comboCol7.HeaderText = "profesija";
                comboCol7.ValueMember = "profesija_id"; 
                comboCol7.DisplayMember = "nosaukums";  
                comboCol7.DataPropertyName = "id_profesija";
                dataGridView1.Columns.Add(comboCol7);

                DataGridViewComboBoxColumn comboCol8 = new DataGridViewComboBoxColumn();
                comboCol8.DataSource = dtizglitiba;
                comboCol8.HeaderText = "izglitiba";
                comboCol8.ValueMember = "izglitiba_id"; 
                comboCol8.DisplayMember = "nosaukums";  
                comboCol8.DataPropertyName = "id_izglitiba";
                dataGridView1.Columns.Add(comboCol8);

                
            


            dataGridView1.Columns["persona_id"].Visible = false;
            dataGridView1.Columns["id_dzimums"].Visible = false;
            dataGridView1.Columns["id_vecuma_grupa"].Visible = false;
            dataGridView1.Columns["id_nacionalitate"].Visible = false;
            dataGridView1.Columns["id_deklareta_dzivesvieta"].Visible = false;
            dataGridView1.Columns["id_pilsoniba"].Visible = false;
            dataGridView1.Columns["id_invaliditate"].Visible = false;
            dataGridView1.Columns["id_profesija"].Visible = false;
            dataGridView1.Columns["id_izglitiba"].Visible = false;
            #endregion
        }
    }
}
