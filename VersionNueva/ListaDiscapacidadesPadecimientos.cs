using System;
using System.Collections;

namespace AtencionTemprana
{
    public class ListaDiscapacidadesPadecimientos
    {
        public ArrayList cargarPadecimientos()
        {
            ArrayList list = new ArrayList();
            list.Add("ALERGIAS");
            list.Add("ARTRITIS");
            list.Add("ASMA");
            list.Add("BRONQUITIS");
            list.Add("CIRROSIS");
            list.Add("DEPRESION");
            list.Add("DIABETES");
            list.Add("DROGADICCION");
            list.Add("ESQUIZOFRENIA");
            list.Add("GASTRITIS");
            list.Add("HEPATITIS");
            list.Add("HIPERTENSION");
            list.Add("MIGRAÑA");
            list.Add("NERVIOS");
            list.Add("PRESION Y DIABETES");
            list.Add("PRESION ARTERIAL ALTA");
            list.Add("PRESION ARTERIAL BAJA");
            list.Add("PSORIASIS");
            list.Add("RESPIRATORIO");
            list.Add("SINOCITIS CRONICA");
            list.Add("5 MESES DE GESTACION");
            return list;
        }


        public ArrayList cargarEnfermedadesSistematicas()
        {
            ArrayList list = new ArrayList();
            list.Add("AFECTACION HEMATOLOGICA");
            list.Add("AFECTACION NEUROLOGICA");
            list.Add("AFECTACION RENAL");
            list.Add("ALTERACION INMUNOLOGICA");
            list.Add("ANTICUERPOS ANTINUCLEARES");
            list.Add("ARTRITIS");
            list.Add("EXANTEMA MALAR");
            list.Add("FOTOSENSIBILIDAD");
            list.Add("LUPUS DISCOIDE");
            list.Add("SEROSITIS");
            list.Add("ULCERAS ORALES O NASOFARINGEAS");
            return list;
        }

        public ArrayList cargargarEnfermedadesMentales()
        {
            ArrayList list = new ArrayList();
            list.Add("AGORAFOBIA");
            list.Add("ANOREXIA NERVIOSA");
            list.Add("ANSIEDAD");
            list.Add("AUTISMO");
            list.Add("BRUXISMO");
            list.Add("BULIMIA");
            list.Add("COMPLEJO DE CULPABILIDAD");
            list.Add("COMPLEJO DE INFERIORIDAD");
            list.Add("COMPLEJO DE SUPERIORIDAD");
            list.Add("DEMENCIA");
            list.Add("DEPRESION");
            list.Add("EL PODER DEL NATIVE");
            list.Add("ESQUIZOFRENIA");
            list.Add("HISTERIA");
            list.Add("NEUROTICISMO");
            list.Add("PARALISIS CEREBRAL");
            list.Add("PSICOPATIA");
            list.Add("SINDROME DE DOWN");
            list.Add("TRASTORNO BIPOLAR");
            list.Add("TRASTORNO OBSESIVO COMPULSIVO");
            list.Add("VIGOREXIA");
            return list;
        }

        public ArrayList cargarEnfermedadesPiel() 
        {
            ArrayList list = new ArrayList();
            list.Add("ACNE");
            list.Add("ALOEPECIA AREATA");
            list.Add("CANCER DE PIEL");
            list.Add("DERMATITIS ATOPICA");
            list.Add("ECZEMA");
            list.Add("ESCABIOSIS O SARNA");
            list.Add("PSORIASIS");
            list.Add("QUEMADURAS");
            list.Add("ROSACEA");
            list.Add("URTICARIA ATOPICA");
            list.Add("VERRUGAS");
            return list;
        }

        public ArrayList cargarAdicciones()
        {
            ArrayList list = new ArrayList();
            list.Add("ADICCION A INTERNET");
            list.Add("ADICCION A VIDEOJUEGOS");
            list.Add("ALCOLISMO");
            list.Add("DROGADICCION COCAINA");
            list.Add("DROGADICCION MARIHUANA");
            list.Add("JUEGOS DE AZAR");
            list.Add("TABAQUISMO");
            return list;
        }

        public ArrayList cargarMedicamentos()
        {
            ArrayList list = new ArrayList();
            list.Add("ACATINOL");
            list.Add("ACIDO FOLICO");
            list.Add("AFRINEX");
            list.Add("AKINENTOLRETAL");
            list.Add("ALBENDAZOL");
            list.Add("AMOXICILINA");
            list.Add("AMPICILINA");
            list.Add("BUPIVACAINA");
            list.Add("CABAMASEPINA");
            list.Add("CAPTOPRIL");
            list.Add("COMPLEJO B");
            list.Add("COPRIDOGEL");
            list.Add("ISISORVIDE");
            list.Add("ENALAPRIL");
            list.Add("MERFORMINA");
            list.Add("DESENFRIOLD");
            list.Add("DEXAMETASONA");
            list.Add("DIAZEPAM");
            list.Add("ENALAPRIL");
            list.Add("FENITOINA");
            list.Add("FENOBARBITAL");
            list.Add("FLOXATINA");
            list.Add("HIDROCORTISONA");
            list.Add("IBOPRUFENO");
            list.Add("INSULINA");
            list.Add("ISISORVIDE");
            list.Add("LANZAPINA");
            list.Add("LIDOCAINA");
            list.Add("MEDICAMENTO HOMEOPATICO");
            list.Add("MERFORMINA");
            list.Add("MORFINA");
            list.Add("NICLOSAMIDA");
            list.Add("OLANZAPINA");
            list.Add("OMEPRAZOL");
            list.Add("OXIGENO");
            list.Add("PARACETAMOL");
            list.Add("RIOPAN");
            list.Add("SUPLEMENTOS ALIMENTICIOS");
            list.Add("VALPURATO DE MAGNESIO");
            return list;
        }

        public ArrayList cargarCirugias()
        {
            ArrayList list = new ArrayList();
            list.Add("ABDOMEN ABAJO");
            list.Add("AMIGDALAS");
            list.Add("ANGINAS");
            list.Add("APENDICE");
            list.Add("BOCA");
            list.Add("CABEZA");
            list.Add("CADERA");
            list.Add("CESAREA");
            list.Add("CODOS");
            list.Add("COLUMNA");
            list.Add("COSTILLAS");
            list.Add("DEDOS MANOS");
            list.Add("DEDOS PIES");
            list.Add("ESTOMAGO");
            list.Add("HERNIA INGLAR");
            list.Add("HIGADO");
            list.Add("INTESTINO");
            list.Add("LABIO LEPORINO");
            list.Add("LENGUA");
            list.Add("MANOS");
            list.Add("MATRIZ");
            list.Add("NARIZ");
            list.Add("OJOS");
            list.Add("OREJAS");
            list.Add("PIES");
            list.Add("RIÑONES");
            list.Add("RODILLA");
            list.Add("SENOS");
            list.Add("TESTICULOS");
            list.Add("VESICULA");
            return list;
        }

    }
}
