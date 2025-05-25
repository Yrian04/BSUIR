(* Content-type: application/vnd.wolfram.cdf.text *)

(*** Wolfram CDF File ***)
(* http://www.wolfram.com/cdf *)

(* CreatedBy='Mathematica 13.3' *)

(***************************************************************************)
(*                                                                         *)
(*                                                                         *)
(*  Under the Wolfram FreeCDF terms of use, this file and its content are  *)
(*  bound by the Creative Commons BY-SA Attribution-ShareAlike license.    *)
(*                                                                         *)
(*        For additional information concerning CDF licensing, see:        *)
(*                                                                         *)
(*         www.wolfram.com/cdf/adopting-cdf/licensing-options.html         *)
(*                                                                         *)
(*                                                                         *)
(***************************************************************************)

(*CacheID: 234*)
(* Internal cache information:
NotebookFileLineBreakTest
NotebookFileLineBreakTest
NotebookDataPosition[      1088,         20]
NotebookDataLength[     19538,        598]
NotebookOptionsPosition[     18357,        564]
NotebookOutlinePosition[     18758,        580]
CellTagsIndexPosition[     18715,        577]
WindowFrame->Normal*)

(* Beginning of Notebook Content *)
Notebook[{

Cell[CellGroupData[{
Cell["\:0417\:0430\:0434\:0430\:043d\:0438\:0435 \:21162", "Title",
 CellChangeTimes->{{3.905913174082382*^9, 3.905913178388834*^9}, {
  3.9059132261543503`*^9, 3.9059132854099646`*^9}, {3.905913383079564*^9, 
  3.905913383845592*^9}},ExpressionUUID->"5a5b088b-da1a-4289-bd0d-\
42b1ea567522"],

Cell["\:0421\:0442\:0443\:0434\:0435\:043d\:0442 \:0433\:0440\:0443\:043f\
\:043f\:044b 221701, \:0413\:043b\:0451\:0437\:0430 \
\:0415\:0433\:043e\:0440", "Subtitle",
 CellChangeTimes->{{3.9059132903534813`*^9, 
  3.9059133266764593`*^9}},ExpressionUUID->"fedcc586-c054-4b8c-9a92-\
9329b94c5e00"],

Cell[CellGroupData[{

Cell[BoxData[
 RowBox[{
  RowBox[{"(*", 
   RowBox[{
   "\:0417\:0430\:0434\:0430\:0434\:0438\:043c", " ", 
    "\:0441\:0438\:0441\:0442\:0435\:043c\:0443"}], "*)"}], 
  "\[IndentingNewLine]", 
  RowBox[{
   RowBox[{
    RowBox[{"n", "=", "5"}], ";"}], "\[IndentingNewLine]", 
   RowBox[{
    RowBox[{"X", " ", "=", " ", 
     RowBox[{
      RowBox[{"Table", "[", 
       RowBox[{
        SubscriptBox["x", "i"], ",", 
        RowBox[{"{", 
         RowBox[{"i", ",", "1", ",", "n", ",", "1"}], "}"}]}], "]"}], "//", 
      "Transpose"}]}], ";"}], "\[IndentingNewLine]", 
   RowBox[{
    RowBox[{"a", "=", " ", 
     RowBox[{"{", 
      RowBox[{"0", ",", "2", ",", "5", ",", "4", ",", "2"}], "}"}]}], ";"}], 
   "\[IndentingNewLine]", 
   RowBox[{
    RowBox[{"b", "=", " ", 
     RowBox[{"{", 
      RowBox[{"4", ",", "10", ",", "20", ",", "10", ",", 
       RowBox[{"-", "3"}]}], "}"}]}], ";"}], "\[IndentingNewLine]", 
   RowBox[{
    RowBox[{"c", " ", "=", " ", 
     RowBox[{"{", 
      RowBox[{
       RowBox[{"-", "1"}], ",", "4", ",", "3", ",", 
       RowBox[{"-", "1"}], ",", "0"}], "}"}]}], ";"}], "\[IndentingNewLine]", 
   RowBox[{
    RowBox[{
     RowBox[{"f", "[", "i_", "]"}], ":=", " ", 
     RowBox[{"Table", "[", 
      RowBox[{
       RowBox[{"If", "[", 
        RowBox[{
         RowBox[{"j", "==", 
          RowBox[{"i", "-", "1"}]}], ",", " ", 
         RowBox[{"a", "[", 
          RowBox[{"[", "i", "]"}], "]"}], ",", " ", 
         RowBox[{"If", "[", 
          RowBox[{
           RowBox[{"j", " ", "==", " ", "i"}], ",", " ", 
           RowBox[{"b", "[", 
            RowBox[{"[", "i", "]"}], "]"}], ",", " ", 
           RowBox[{"If", "[", 
            RowBox[{
             RowBox[{"j", "==", 
              RowBox[{"i", "+", "1"}]}], ",", " ", 
             RowBox[{"c", "[", 
              RowBox[{"[", "i", "]"}], "]"}], ",", "0"}], "]"}]}], "]"}]}], 
        "]"}], ",", 
       RowBox[{"{", 
        RowBox[{"j", ",", "1", ",", "n", ",", "1"}], "}"}]}], "]"}]}], ";"}], 
   "\[IndentingNewLine]", 
   RowBox[{
    RowBox[{"A", "=", " ", 
     RowBox[{"Table", "[", 
      RowBox[{
       RowBox[{"f", "[", "i", "]"}], ",", 
       RowBox[{"{", 
        RowBox[{"i", ",", "1", ",", "n", ",", "1"}], "}"}]}], "]"}]}], ";"}], 
   "\[IndentingNewLine]", 
   RowBox[{
    RowBox[{"B", " ", "=", " ", 
     RowBox[{
      RowBox[{"{", 
       RowBox[{"5", ",", "18", ",", 
        RowBox[{"-", "50"}], ",", "30", ",", 
        RowBox[{"-", "2"}]}], "}"}], "//", "Transpose"}]}], ";"}], 
   "\[IndentingNewLine]", 
   RowBox[{
    RowBox[{
     RowBox[{"MatrixForm", "[", "A", "]"}], ".", 
     RowBox[{"MatrixForm", "[", "X", "]"}]}], "==", 
    RowBox[{"MatrixForm", "[", "B", "]"}]}]}]}]], "Input",
 CellChangeTimes->{{3.904822736654131*^9, 3.904822762454157*^9}, {
   3.904822798648382*^9, 3.904823037824094*^9}, {3.9048230780081406`*^9, 
   3.9048231259739866`*^9}, {3.904823178378209*^9, 3.904823203404138*^9}, 
   3.9048232495246367`*^9, {3.9048232946559563`*^9, 3.904823311806587*^9}, {
   3.904823342894189*^9, 3.9048234100743246`*^9}, {3.9048235203741627`*^9, 
   3.904823560374069*^9}, {3.904823617124045*^9, 3.9048236178443747`*^9}, {
   3.904823743474475*^9, 3.904824169084275*^9}, {3.9048242213042126`*^9, 
   3.904824246854183*^9}, {3.90482525624363*^9, 3.904825261093851*^9}, {
   3.904825301772013*^9, 3.904825363352214*^9}, {3.904825760711873*^9, 
   3.9048257866338615`*^9}},
 CellLabel->
  "In[202]:=",ExpressionUUID->"234d906f-a59f-4cd2-a639-e6d781413b18"],

Cell[BoxData[
 RowBox[{
  RowBox[{
   TagBox[
    RowBox[{"(", "\[NoBreak]", GridBox[{
       {"4", 
        RowBox[{"-", "1"}], "0", "0", "0"},
       {"2", "10", "4", "0", "0"},
       {"0", "5", "20", "3", "0"},
       {"0", "0", "4", "10", 
        RowBox[{"-", "1"}]},
       {"0", "0", "0", "2", 
        RowBox[{"-", "3"}]}
      },
      GridBoxAlignment->{"Columns" -> {{Center}}, "Rows" -> {{Baseline}}},
      GridBoxSpacings->{"Columns" -> {
          Offset[0.27999999999999997`], {
           Offset[0.7]}, 
          Offset[0.27999999999999997`]}, "Rows" -> {
          Offset[0.2], {
           Offset[0.4]}, 
          Offset[0.2]}}], "\[NoBreak]", ")"}],
    Function[BoxForm`e$, 
     MatrixForm[BoxForm`e$]]], ".", 
   TagBox[
    RowBox[{"(", "\[NoBreak]", 
     TagBox[GridBox[{
        {
         SubscriptBox["x", "1"]},
        {
         SubscriptBox["x", "2"]},
        {
         SubscriptBox["x", "3"]},
        {
         SubscriptBox["x", "4"]},
        {
         SubscriptBox["x", "5"]}
       },
       GridBoxAlignment->{"Columns" -> {{Center}}, "Rows" -> {{Baseline}}},
       GridBoxSpacings->{"Columns" -> {
           Offset[0.27999999999999997`], {
            Offset[0.5599999999999999]}, 
           Offset[0.27999999999999997`]}, "Rows" -> {
           Offset[0.2], {
            Offset[0.4]}, 
           Offset[0.2]}}],
      Column], "\[NoBreak]", ")"}],
    Function[BoxForm`e$, 
     MatrixForm[BoxForm`e$]]]}], "\[Equal]", 
  TagBox[
   RowBox[{"(", "\[NoBreak]", 
    TagBox[GridBox[{
       {"5"},
       {"18"},
       {
        RowBox[{"-", "50"}]},
       {"30"},
       {
        RowBox[{"-", "2"}]}
      },
      GridBoxAlignment->{"Columns" -> {{Center}}, "Rows" -> {{Baseline}}},
      GridBoxSpacings->{"Columns" -> {
          Offset[0.27999999999999997`], {
           Offset[0.5599999999999999]}, 
          Offset[0.27999999999999997`]}, "Rows" -> {
          Offset[0.2], {
           Offset[0.4]}, 
          Offset[0.2]}}],
     Column], "\[NoBreak]", ")"}],
   Function[BoxForm`e$, 
    MatrixForm[BoxForm`e$]]]}]], "Output",
 CellChangeTimes->{{3.9048240070941505`*^9, 3.9048240457741585`*^9}, {
   3.904824113652111*^9, 3.9048241702445498`*^9}, 3.904824248214168*^9, {
   3.9048257838939247`*^9, 3.90482578752386*^9}, 3.9069655194845614`*^9, 
   3.9069655980445657`*^9},
 CellLabel->
  "Out[210]=",ExpressionUUID->"bb03df1f-8390-4722-856c-ee884f8afcdf"]
}, Open  ]],

Cell[CellGroupData[{

Cell["\:0412\:044b\:0447\:0438\:0441\:043b\:0438\:043c \:043f\:0440\:043e\
\:0433\:043e\:043d\:043e\:0447\:043d\:044b\:0435 \:043a\:043e\:044d\:0444\
\:0444\:0438\:0446\:0438\:0435\:043d\:0442\:044b", "Subsection",
 CellChangeTimes->{{3.90696542636939*^9, 
  3.90696546245685*^9}},ExpressionUUID->"fc47971f-2acd-417e-9e51-\
098d17f93cb4"],

Cell[CellGroupData[{

Cell[BoxData[{
 RowBox[{
  RowBox[{"L", " ", "=", " ", 
   RowBox[{"Table", "[", 
    RowBox[{"0", ",", 
     RowBox[{"{", 
      RowBox[{"i", ",", "1", ",", "n", ",", "1"}], "}"}]}], "]"}]}], ";", 
  RowBox[{
   RowBox[{"L", "[", 
    RowBox[{"[", "1", "]"}], "]"}], "=", 
   FractionBox[
    RowBox[{"-", 
     RowBox[{"c", "[", 
      RowBox[{"[", "1", "]"}], "]"}]}], 
    RowBox[{"b", "[", 
     RowBox[{"[", "1", "]"}], "]"}]]}], ";"}], "\[IndentingNewLine]", 
 RowBox[{
  RowBox[{"Do", "[", 
   RowBox[{
    RowBox[{
     RowBox[{"L", "[", 
      RowBox[{"[", "i", "]"}], "]"}], "=", 
     FractionBox[
      RowBox[{"-", 
       RowBox[{"c", "[", 
        RowBox[{"[", "i", "]"}], "]"}]}], 
      RowBox[{
       RowBox[{"b", "[", 
        RowBox[{"[", "i", "]"}], "]"}], "+", 
       RowBox[{
        RowBox[{"a", "[", 
         RowBox[{"[", "i", "]"}], "]"}], 
        RowBox[{"L", "[", 
         RowBox[{"[", 
          RowBox[{"i", "-", "1"}], "]"}], "]"}]}]}]]}], ",", 
    RowBox[{"{", 
     RowBox[{"i", ",", "2", ",", "n", ",", "1"}], "}"}]}], "]"}], 
  ";"}], "\[IndentingNewLine]", 
 RowBox[{"L", "//", "MatrixForm"}]}], "Input",
 CellChangeTimes->{{3.904824364522207*^9, 3.9048244135043507`*^9}, {
  3.9048244901939173`*^9, 3.9048245209542537`*^9}, {3.904824629694389*^9, 
  3.9048246345062447`*^9}, {3.904824707164282*^9, 3.904825207323223*^9}, {
  3.9048253680236683`*^9, 3.904825391314454*^9}, {3.904825457461912*^9, 
  3.9048255042385936`*^9}, {3.9048257967839108`*^9, 3.9048258030438633`*^9}, {
  3.9069654078141603`*^9, 3.9069654213258996`*^9}, {3.906965506100591*^9, 
  3.9069655123205442`*^9}},
 CellLabel->
  "In[211]:=",ExpressionUUID->"4a28a5d6-42f4-401a-bf42-d8e2c2829e35"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", 
   TagBox[GridBox[{
      {
       FractionBox["1", "4"]},
      {
       RowBox[{"-", 
        FractionBox["8", "21"]}]},
      {
       RowBox[{"-", 
        FractionBox["63", "380"]}]},
      {
       FractionBox["95", "887"]},
      {"0"}
     },
     GridBoxAlignment->{"Columns" -> {{Center}}, "Rows" -> {{Baseline}}},
     GridBoxSpacings->{"Columns" -> {
         Offset[0.27999999999999997`], {
          Offset[0.5599999999999999]}, 
         Offset[0.27999999999999997`]}, "Rows" -> {
         Offset[0.2], {
          Offset[0.4]}, 
         Offset[0.2]}}],
    Column], "\[NoBreak]", ")"}],
  Function[BoxForm`e$, 
   MatrixForm[BoxForm`e$]]]], "Output",
 CellChangeTimes->{3.9069655981228*^9},
 CellLabel->
  "Out[213]//MatrixForm=",ExpressionUUID->"ff1b2e50-f461-41f5-898b-\
b6ad6d8779d6"]
}, Open  ]],

Cell[CellGroupData[{

Cell["L", "Subsubsection",
 CellChangeTimes->{{3.9069655584092064`*^9, 3.906965562909439*^9}, {
  3.906983084228573*^9, 
  3.9069830853320155`*^9}},ExpressionUUID->"b36bb208-c57d-4e43-90a1-\
c7249d2a4c89"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", 
   TagBox[GridBox[{
      {
       FractionBox["1", "4"]},
      {
       RowBox[{"-", 
        FractionBox["8", "21"]}]},
      {
       RowBox[{"-", 
        FractionBox["63", "380"]}]},
      {
       FractionBox["95", "887"]},
      {"0"}
     },
     GridBoxAlignment->{"Columns" -> {{Center}}, "Rows" -> {{Baseline}}},
     GridBoxSpacings->{"Columns" -> {
         Offset[0.27999999999999997`], {
          Offset[0.5599999999999999]}, 
         Offset[0.27999999999999997`]}, "Rows" -> {
         Offset[0.2], {
          Offset[0.4]}, 
         Offset[0.2]}}],
    Column], "\[NoBreak]", ")"}],
  Function[BoxForm`e$, 
   MatrixForm[BoxForm`e$]]]], "Output",
 CellChangeTimes->{3.9069655195429163`*^9},
 CellLabel->
  "Out[194]//MatrixForm=",ExpressionUUID->"ab51c217-85cc-4ff5-8617-\
ff71aa62e232"],

Cell[CellGroupData[{

Cell[BoxData[{
 RowBox[{
  RowBox[{"M", " ", "=", " ", 
   RowBox[{"Table", "[", 
    RowBox[{"0", ",", 
     RowBox[{"{", 
      RowBox[{"i", ",", "1", ",", "n", ",", "1"}], "}"}]}], "]"}]}], ";", 
  RowBox[{
   RowBox[{"M", "[", 
    RowBox[{"[", "1", "]"}], "]"}], "=", " ", 
   FractionBox[
    RowBox[{"B", "[", 
     RowBox[{"[", "1", "]"}], "]"}], 
    RowBox[{"b", "[", 
     RowBox[{"[", "1", "]"}], "]"}]]}], ";"}], "\[IndentingNewLine]", 
 RowBox[{
  RowBox[{"Do", "[", 
   RowBox[{
    RowBox[{
     RowBox[{"M", "[", 
      RowBox[{"[", "i", "]"}], "]"}], "=", 
     FractionBox[
      RowBox[{
       RowBox[{"B", "[", 
        RowBox[{"[", "i", "]"}], "]"}], "-", 
       RowBox[{
        RowBox[{"a", "[", 
         RowBox[{"[", "i", "]"}], "]"}], 
        RowBox[{"M", "[", 
         RowBox[{"[", 
          RowBox[{"i", "-", "1"}], "]"}], "]"}]}]}], 
      RowBox[{
       RowBox[{"b", "[", 
        RowBox[{"[", "i", "]"}], "]"}], "+", 
       RowBox[{
        RowBox[{"a", "[", 
         RowBox[{"[", "i", "]"}], "]"}], 
        RowBox[{"L", "[", 
         RowBox[{"[", 
          RowBox[{"i", "-", "1"}], "]"}], "]"}]}]}]]}], ",", 
    RowBox[{"{", 
     RowBox[{"i", ",", "2", ",", "n", ",", "1"}], "}"}]}], "]"}], 
  ";"}], "\[IndentingNewLine]", 
 RowBox[{"M", "//", "MatrixForm"}]}], "Input",
 CellChangeTimes->{{3.904824364522207*^9, 3.9048244135043507`*^9}, {
  3.9048244901939173`*^9, 3.9048245209542537`*^9}, {3.904824629694389*^9, 
  3.9048246345062447`*^9}, {3.904824707164282*^9, 3.904825207323223*^9}, {
  3.9048253680236683`*^9, 3.904825391314454*^9}, {3.904825457461912*^9, 
  3.9048255042385936`*^9}, {3.9048257967839108`*^9, 3.9048258030438633`*^9}, {
  3.9069654078141603`*^9, 3.9069654213258996`*^9}, {3.906965506100591*^9, 
  3.9069655123205442`*^9}},
 CellLabel->
  "In[214]:=",ExpressionUUID->"72f7fd1b-e41d-4e14-ace4-3d1b8f20d054"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", 
   TagBox[GridBox[{
      {
       FractionBox["5", "4"]},
      {
       FractionBox["31", "21"]},
      {
       RowBox[{"-", 
        FractionBox["241", "76"]}]},
      {
       FractionBox["4055", "887"]},
      {"4"}
     },
     GridBoxAlignment->{"Columns" -> {{Center}}, "Rows" -> {{Baseline}}},
     GridBoxSpacings->{"Columns" -> {
         Offset[0.27999999999999997`], {
          Offset[0.5599999999999999]}, 
         Offset[0.27999999999999997`]}, "Rows" -> {
         Offset[0.2], {
          Offset[0.4]}, 
         Offset[0.2]}}],
    Column], "\[NoBreak]", ")"}],
  Function[BoxForm`e$, 
   MatrixForm[BoxForm`e$]]]], "Output",
 CellChangeTimes->{3.906965598138378*^9},
 CellLabel->
  "Out[216]//MatrixForm=",ExpressionUUID->"8b5e7280-3273-4722-8eb3-\
761c5a83840d"]
}, Open  ]]
}, Open  ]],

Cell[CellGroupData[{

Cell["M", "Subsubsection",
 CellChangeTimes->{{3.906965573193372*^9, 3.906965575903926*^9}, {
  3.906983087261871*^9, 
  3.9069830874249554`*^9}},ExpressionUUID->"23838a13-80fa-4323-b634-\
7ca18b88c08a"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", 
   TagBox[GridBox[{
      {
       FractionBox["5", "4"]},
      {
       FractionBox["31", "21"]},
      {
       RowBox[{"-", 
        FractionBox["241", "76"]}]},
      {
       FractionBox["4055", "887"]},
      {"4"}
     },
     GridBoxAlignment->{"Columns" -> {{Center}}, "Rows" -> {{Baseline}}},
     GridBoxSpacings->{"Columns" -> {
         Offset[0.27999999999999997`], {
          Offset[0.5599999999999999]}, 
         Offset[0.27999999999999997`]}, "Rows" -> {
         Offset[0.2], {
          Offset[0.4]}, 
         Offset[0.2]}}],
    Column], "\[NoBreak]", ")"}],
  Function[BoxForm`e$, 
   MatrixForm[BoxForm`e$]]]], "Output",
 CellChangeTimes->{3.9048258313442783`*^9, 3.9069655195742593`*^9},
 CellLabel->
  "Out[197]//MatrixForm=",ExpressionUUID->"f7d01488-4bba-4067-b999-\
f8170587443f"]
}, Open  ]]
}, Open  ]],

Cell[CellGroupData[{

Cell["\:0412\:044b\:0447\:0438\:0441\:043b\:0438\:043c \:0440\:0435\:0448\
\:0435\:043d\:0438\:0435", "Subsection",
 CellChangeTimes->{
  3.906965592405612*^9},ExpressionUUID->"1fe3a8d0-99f1-4fc8-8515-\
a8f4e34b9446"],

Cell[CellGroupData[{

Cell[BoxData[{
 RowBox[{
  RowBox[{"sol", " ", "=", " ", 
   RowBox[{"Table", "[", 
    RowBox[{
     RowBox[{"M", "[", 
      RowBox[{"[", "n", "]"}], "]"}], ",", 
     RowBox[{"{", 
      RowBox[{"i", ",", "1", ",", "n", ",", "1"}], "}"}]}], "]"}]}], 
  ";"}], "\[IndentingNewLine]", 
 RowBox[{
  RowBox[{"Do", "[", 
   RowBox[{
    RowBox[{
     RowBox[{"sol", "[", 
      RowBox[{"[", "i", "]"}], "]"}], "=", 
     RowBox[{
      RowBox[{
       RowBox[{"L", "[", 
        RowBox[{"[", "i", "]"}], "]"}], 
       RowBox[{"sol", "[", 
        RowBox[{"[", 
         RowBox[{"i", "+", "1"}], "]"}], "]"}]}], "+", 
      RowBox[{"M", "[", 
       RowBox[{"[", "i", "]"}], "]"}]}]}], ",", 
    RowBox[{"{", 
     RowBox[{"i", ",", 
      RowBox[{"n", "-", "1"}], ",", "1", ",", 
      RowBox[{"-", "1"}]}], "}"}]}], "]"}], ";"}], "\[IndentingNewLine]", 
 RowBox[{"sol", "//", "MatrixForm"}]}], "Input",
 CellChangeTimes->{{3.9048255771137857`*^9, 3.9048256053168726`*^9}, {
  3.904825637294033*^9, 3.9048257477725925`*^9}, {3.9048258064489717`*^9, 
  3.9048258191338835`*^9}, {3.906965580634363*^9, 3.9069655865015965`*^9}},
 CellLabel->
  "In[217]:=",ExpressionUUID->"f8dd7d3b-ec8e-4cdd-bddf-b0d9eea3ff4e"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", 
   TagBox[GridBox[{
      {"2"},
      {"3"},
      {
       RowBox[{"-", "4"}]},
      {"5"},
      {"4"}
     },
     GridBoxAlignment->{"Columns" -> {{Center}}, "Rows" -> {{Baseline}}},
     GridBoxSpacings->{"Columns" -> {
         Offset[0.27999999999999997`], {
          Offset[0.5599999999999999]}, 
         Offset[0.27999999999999997`]}, "Rows" -> {
         Offset[0.2], {
          Offset[0.4]}, 
         Offset[0.2]}}],
    Column], "\[NoBreak]", ")"}],
  Function[BoxForm`e$, 
   MatrixForm[BoxForm`e$]]]], "Output",
 CellChangeTimes->{{3.904825727583766*^9, 3.9048257541980114`*^9}, 
   3.9048258241840563`*^9, 3.9069655195898623`*^9, 3.9069655981449633`*^9},
 CellLabel->
  "Out[219]//MatrixForm=",ExpressionUUID->"49967f6a-f805-46ab-a4ad-\
10f8942f74dd"]
}, Open  ]]
}, Open  ]]
}, Open  ]]
},
WindowSize->{1141.2, 574.8},
WindowMargins->{{0, Automatic}, {Automatic, 0}},
FrontEndVersion->"13.3 for Microsoft Windows (64-bit) (July 24, 2023)",
StyleDefinitions->"Default.nb",
ExpressionUUID->"ba239ef8-d9d1-4bd6-8bdf-cce7d78aec50"
]
(* End of Notebook Content *)

(* Internal cache information *)
(*CellTagsOutline
CellTagsIndex->{}
*)
(*CellTagsIndex
CellTagsIndex->{}
*)
(*NotebookFileOutline
Notebook[{
Cell[CellGroupData[{
Cell[1510, 35, 292, 4, 98, "Title",ExpressionUUID->"5a5b088b-da1a-4289-bd0d-42b1ea567522"],
Cell[1805, 41, 297, 5, 53, "Subtitle",ExpressionUUID->"fedcc586-c054-4b8c-9a92-9329b94c5e00"],
Cell[CellGroupData[{
Cell[2127, 50, 3509, 93, 279, "Input",ExpressionUUID->"234d906f-a59f-4cd2-a639-e6d781413b18"],
Cell[5639, 145, 2423, 76, 97, "Output",ExpressionUUID->"bb03df1f-8390-4722-856c-ee884f8afcdf"]
}, Open  ]],
Cell[CellGroupData[{
Cell[8099, 226, 338, 5, 54, "Subsection",ExpressionUUID->"fc47971f-2acd-417e-9e51-098d17f93cb4"],
Cell[CellGroupData[{
Cell[8462, 235, 1704, 47, 157, "Input",ExpressionUUID->"4a28a5d6-42f4-401a-bf42-d8e2c2829e35"],
Cell[10169, 284, 857, 30, 143, "Output",ExpressionUUID->"ff1b2e50-f461-41f5-898b-b6ad6d8779d6"]
}, Open  ]],
Cell[CellGroupData[{
Cell[11063, 319, 205, 4, 45, "Subsubsection",ExpressionUUID->"b36bb208-c57d-4e43-90a1-c7249d2a4c89"],
Cell[11271, 325, 861, 30, 143, "Output",ExpressionUUID->"ab51c217-85cc-4ff5-8617-ff71aa62e232"],
Cell[CellGroupData[{
Cell[12157, 359, 1874, 52, 157, "Input",ExpressionUUID->"72f7fd1b-e41d-4e14-ace4-3d1b8f20d054"],
Cell[14034, 413, 838, 29, 143, "Output",ExpressionUUID->"8b5e7280-3273-4722-8eb3-761c5a83840d"]
}, Open  ]]
}, Open  ]],
Cell[CellGroupData[{
Cell[14921, 448, 203, 4, 45, "Subsubsection",ExpressionUUID->"23838a13-80fa-4323-b634-7ca18b88c08a"],
Cell[15127, 454, 864, 29, 143, "Output",ExpressionUUID->"f7d01488-4bba-4067-b999-f8170587443f"]
}, Open  ]]
}, Open  ]],
Cell[CellGroupData[{
Cell[16040, 489, 217, 4, 54, "Subsection",ExpressionUUID->"1fe3a8d0-99f1-4fc8-8515-a8f4e34b9446"],
Cell[CellGroupData[{
Cell[16282, 497, 1207, 34, 114, "Input",ExpressionUUID->"f8dd7d3b-ec8e-4cdd-bddf-b0d9eea3ff4e"],
Cell[17492, 533, 825, 26, 111, "Output",ExpressionUUID->"49967f6a-f805-46ab-a4ad-10f8942f74dd"]
}, Open  ]]
}, Open  ]]
}, Open  ]]
}
]
*)

(* NotebookSignature wxpJgzc1LZE9FDKrDKum#WXI *)
