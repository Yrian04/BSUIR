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
NotebookDataLength[     32371,        888]
NotebookOptionsPosition[     29653,        822]
NotebookOutlinePosition[     30305,        845]
CellTagsIndexPosition[     30262,        842]
WindowFrame->Normal*)

(* Beginning of Notebook Content *)
Notebook[{

Cell[CellGroupData[{
Cell["\:0417\:0430\:0434\:0430\:043d\:0438\:0435 \:21161.1", "Title",
 CellChangeTimes->{{3.905913174082382*^9, 3.905913178388834*^9}, {
  3.9059132261543503`*^9, 
  3.9059132854099646`*^9}},ExpressionUUID->"046d3c4c-88d4-47a7-835d-\
2e3a362b76a6"],

Cell["\:0421\:0442\:0443\:0434\:0435\:043d\:0442 \:0433\:0440\:0443\:043f\
\:043f\:044b 221701, \:0413\:043b\:0451\:0437\:0430 \
\:0415\:0433\:043e\:0440", "Subtitle",
 CellChangeTimes->{{3.9059132903534813`*^9, 
  3.9059133266764593`*^9}},ExpressionUUID->"78f3ad62-952d-4eb4-809c-\
3b3153d84216"],

Cell[CellGroupData[{

Cell[BoxData[
 RowBox[{
  RowBox[{"(*", 
   RowBox[{
   "\:041e\:043f\:0440\:0435\:0434\:0435\:043b\:0438\:043c", " ", 
    "\:043c\:0430\:0442\:0440\:0438\:0446\:0443", " ", "\:0410"}], "*)"}], 
  "\[IndentingNewLine]", 
  RowBox[{
   RowBox[{
    RowBox[{
     RowBox[{"a", "[", 
      RowBox[{"i_", ",", " ", "j_"}], "]"}], " ", ":=", " ", 
     RowBox[{"If", "[", 
      RowBox[{
       RowBox[{"i", "==", "j"}], ",", " ", 
       RowBox[{"i", "+", "1"}], ",", " ", 
       RowBox[{"If", "[", 
        RowBox[{
         RowBox[{"i", ">", "j"}], ",", " ", "1", ",", " ", "2", ",", "0"}], 
        "]"}], ",", "0"}], "]"}]}], ";", " ", 
    RowBox[{"A", "=", 
     RowBox[{"Table", "[", 
      RowBox[{
       RowBox[{"a", "[", 
        RowBox[{"i", ",", " ", "j"}], "]"}], ",", " ", 
       RowBox[{"{", 
        RowBox[{"i", ",", "1", ",", "7", ",", "1"}], "}"}], ",", 
       RowBox[{"{", 
        RowBox[{"j", ",", "1", ",", "7", ",", "1"}], "}"}]}], "]"}]}], ";"}], 
   "\[IndentingNewLine]", 
   RowBox[{"A", "//", "MatrixForm"}]}]}]], "Input",
 CellChangeTimes->{{3.9048146683428993`*^9, 3.904814670707016*^9}, {
   3.9048150739574337`*^9, 3.9048152026645985`*^9}, {3.904815254997858*^9, 
   3.9048152957376604`*^9}, {3.9048153269815025`*^9, 3.904815358770699*^9}, {
   3.904815550889892*^9, 3.9048155524849997`*^9}, {3.904815642531085*^9, 
   3.904815656624695*^9}, 3.9048157042030287`*^9, {3.9048157377649603`*^9, 
   3.9048157984669313`*^9}, {3.9048159093655815`*^9, 3.904815993842948*^9}, {
   3.9048162807952433`*^9, 3.904816335832986*^9}, 3.904817557064978*^9, {
   3.904819647844506*^9, 3.90481965485476*^9}},
 CellLabel->
  "In[108]:=",ExpressionUUID->"436f2075-44db-4973-97ba-a0b70f22ee5f"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", GridBox[{
     {"2", "2", "2", "2", "2", "2", "2"},
     {"1", "3", "2", "2", "2", "2", "2"},
     {"1", "1", "4", "2", "2", "2", "2"},
     {"1", "1", "1", "5", "2", "2", "2"},
     {"1", "1", "1", "1", "6", "2", "2"},
     {"1", "1", "1", "1", "1", "7", "2"},
     {"1", "1", "1", "1", "1", "1", "8"}
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
   MatrixForm[BoxForm`e$]]]], "Output",
 CellChangeTimes->{
  3.9048159951708508`*^9, 3.904816340685983*^9, 3.9048175578046985`*^9, 
   3.9048196557945356`*^9, 3.9069636184330153`*^9, 3.906964254009261*^9, {
   3.9069650882779293`*^9, 3.9069651002346883`*^9}},
 CellLabel->
  "Out[109]//MatrixForm=",ExpressionUUID->"ab7317f3-e9db-436e-8750-\
a8dd9df07b72"]
}, Open  ]],

Cell[CellGroupData[{

Cell[BoxData[
 RowBox[{
  RowBox[{"(*", 
   RowBox[{
    RowBox[{
    "\:041e\:043f\:0440\:0435\:0434\:0435\:043b\:0438\:043c", " ", 
     "\:0432\:0435\:043a\:0442\:043e\:0440"}], "-", 
    RowBox[{"\:0441\:0442\:043e\:043b\:0431\:0435\:0446", " ", "b"}]}], 
   "*)"}], "\[IndentingNewLine]", 
  RowBox[{
   RowBox[{
    RowBox[{
     RowBox[{"b", "[", "i_", "]"}], ":=", 
     RowBox[{
      RowBox[{"2", "*", "1", "*", "i"}], "-", 
      SuperscriptBox["i", "2"]}]}], ";"}], "\[IndentingNewLine]", 
   RowBox[{
    RowBox[{"B", "=", 
     RowBox[{"Table", "[", 
      RowBox[{
       RowBox[{"b", "[", "i", "]"}], ",", 
       RowBox[{"{", 
        RowBox[{"i", ",", "1", ",", "7", ",", "1"}], "}"}]}], "]"}]}], ";"}], 
   "\[IndentingNewLine]", 
   RowBox[{"B", "//", "MatrixForm"}]}]}]], "Input",
 CellChangeTimes->{{3.904816378140554*^9, 3.9048165966248217`*^9}, 
   3.9048175653550253`*^9, {3.9048196602147045`*^9, 3.904819668044608*^9}},
 CellLabel->
  "In[110]:=",ExpressionUUID->"52f22b8e-8c78-4441-bb23-de208cea72de"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", 
   TagBox[GridBox[{
      {"1"},
      {"0"},
      {
       RowBox[{"-", "3"}]},
      {
       RowBox[{"-", "8"}]},
      {
       RowBox[{"-", "15"}]},
      {
       RowBox[{"-", "24"}]},
      {
       RowBox[{"-", "35"}]}
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
 CellChangeTimes->{
  3.9048165974483757`*^9, 3.90481756606498*^9, 3.9048196688973136`*^9, 
   3.906963729622769*^9, 3.906964254058442*^9, {3.9069650883377757`*^9, 
   3.9069651002882214`*^9}},
 CellLabel->
  "Out[112]//MatrixForm=",ExpressionUUID->"b0f97da6-0d41-47d7-b6ad-\
fa1a950a257e"]
}, Open  ]],

Cell[CellGroupData[{

Cell[BoxData[
 RowBox[{
  RowBox[{"(*", 
   RowBox[{
    RowBox[{
    "\:041e\:043f\:0440\:0435\:0434\:0435\:043b\:0438\:043c", " ", 
     "\:0432\:0435\:043a\:0442\:043e\:0440"}], "-", 
    RowBox[{"\:0441\:0442\:043e\:043b\:0431\:0435\:0446", " ", "X"}]}], 
   "*)"}], "\[IndentingNewLine]", 
  RowBox[{
   RowBox[{
    RowBox[{"X", " ", "=", 
     RowBox[{"{", 
      RowBox[{
       RowBox[{"{", "x1", "}"}], ",", 
       RowBox[{"{", "x2", "}"}], ",", 
       RowBox[{"{", "x3", "}"}], ",", 
       RowBox[{"{", "x4", "}"}], ",", 
       RowBox[{"{", "x5", "}"}], ",", 
       RowBox[{"{", "x6", "}"}], ",", 
       RowBox[{"{", "x7", "}"}]}], "}"}]}], ";"}], "\[IndentingNewLine]", 
   RowBox[{"X", "//", "MatrixForm"}]}]}]], "Input",
 CellChangeTimes->{{3.9048166518947163`*^9, 3.90481668909982*^9}, {
   3.9048168103352227`*^9, 3.904816852655043*^9}, {3.9048169220916004`*^9, 
   3.9048169246683865`*^9}, 3.904817348775031*^9, {3.9048175697549005`*^9, 
   3.904817577824885*^9}, {3.904819677955688*^9, 3.9048196824525223`*^9}},
 CellLabel->
  "In[113]:=",ExpressionUUID->"6a70395b-8962-483c-bbef-8afe1b33d867"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", GridBox[{
     {"x1"},
     {"x2"},
     {"x3"},
     {"x4"},
     {"x5"},
     {"x6"},
     {"x7"}
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
   MatrixForm[BoxForm`e$]]]], "Output",
 CellChangeTimes->{
  3.9048168536348066`*^9, 3.904816925617053*^9, {3.9048175702550645`*^9, 
   3.904817580548234*^9}, 3.904819683302402*^9, 3.906964126467535*^9, 
   3.9069642540788946`*^9, {3.9069650883377757`*^9, 3.9069651002882214`*^9}},
 CellLabel->
  "Out[114]//MatrixForm=",ExpressionUUID->"c70b0f87-1160-46d5-874f-\
91ec28c021ad"]
}, Open  ]],

Cell[CellGroupData[{

Cell["\:0430) \:043d\:0430\:0439\:0442\:0438 \:0447\:0438\:0441\:043b\:043e \
\:043e\:0431\:0443\:0441\:043b\:043e\:0432\:043b\:0435\:043d\:043d\:043e\:0441\
\:0442\:0438 \:043c\:0430\:0442\:0440\:0438\:0446\:044b A \:0432 \:043d\:043e\
\:0440\:043c\:0435-\:043c\:0430\:043a\:0441\:0438\:043c\:0443\:043c", \
"Subsection",
 CellChangeTimes->{{3.9069635214880056`*^9, 
  3.9069635235067854`*^9}},ExpressionUUID->"6f0e3deb-e73d-46f1-bc84-\
ffc659383b26"],

Cell[CellGroupData[{

Cell[BoxData[
 RowBox[{"condA", "=", 
  RowBox[{
   RowBox[{"Norm", "[", 
    RowBox[{"A", ",", " ", "Infinity"}], "]"}], "*", 
   RowBox[{"Norm", "[", 
    RowBox[{
     RowBox[{"A", "//", "Inverse"}], ",", " ", "Infinity"}], 
    "]"}]}]}]], "Input",
 CellChangeTimes->{{3.9048183265365763`*^9, 3.904818338994668*^9}, {
  3.904818378554734*^9, 3.904818383554745*^9}, {3.9048184337587233`*^9, 
  3.9048184721048126`*^9}, {3.904818663374809*^9, 3.904818786542117*^9}, {
  3.9048188334985685`*^9, 3.9048188690425053`*^9}, {3.904818948242304*^9, 
  3.9048190613071136`*^9}, {3.9048219109444427`*^9, 3.9048219194943886`*^9}, {
  3.9048219524542637`*^9, 3.9048219528013296`*^9}, {3.906963587730547*^9, 
  3.9069635909684725`*^9}},
 CellLabel->
  "In[115]:=",ExpressionUUID->"502a9aee-e08b-47df-94a8-64c5877856b2"],

Cell[BoxData["25"], "Output",
 CellChangeTimes->{{3.9048189952448483`*^9, 3.9048190255546713`*^9}, 
   3.9048219215643044`*^9, 3.9048219540195274`*^9, 3.906963592255415*^9, 
   3.906963625830762*^9, 3.9069642541005287`*^9, {3.906965088350257*^9, 
   3.9069651002882214`*^9}},
 CellLabel->
  "Out[115]=",ExpressionUUID->"daf97b43-7072-4c3a-a205-58968b07161e"]
}, Open  ]]
}, Open  ]],

Cell[CellGroupData[{

Cell["\:0431) \:0440\:0435\:0448\:0438\:0442\:044c \:0442\:043e\:0447\:043d\
\:0443\:044e \:0441\:0438\:0441\:0442\:0435\:043c\:0443 \:043b\:0438\:043d\
\:0435\:0439\:043d\:044b\:0445 \:0443\:0440\:0430\:0432\:043d\:0435\:043d\
\:0438\:0439", "Subsection",
 CellChangeTimes->{{3.9069636569058714`*^9, 3.9069636630333676`*^9}, {
  3.906964557631766*^9, 
  3.9069645597907085`*^9}},ExpressionUUID->"a1b0e069-378c-42cd-833d-\
4b70eea3c783"],

Cell[CellGroupData[{

Cell[BoxData[{
 RowBox[{
  RowBox[{"sol", " ", "=", " ", 
   RowBox[{"Solve", "[", 
    RowBox[{
     RowBox[{
      RowBox[{"A", ".", "X"}], "==", "B"}], ",", " ", 
     RowBox[{"{", 
      RowBox[{
      "x1", ",", "x2", ",", "x3", ",", "x4", ",", "x5", ",", "x6", ",", 
       "x7"}], "}"}]}], "]"}]}], ";"}], "\[IndentingNewLine]", 
 RowBox[{"sol", "//", "MatrixForm"}]}], "Input",
 CellChangeTimes->{{3.904816867564739*^9, 3.9048168704551897`*^9}, {
  3.9048169406178355`*^9, 3.9048170651788974`*^9}, {3.904817105985165*^9, 
  3.904817109184884*^9}, {3.904817154455039*^9, 3.9048171739449935`*^9}, {
  3.9048172532751713`*^9, 3.904817443629691*^9}, {3.904817587969761*^9, 
  3.904817656408844*^9}, {3.904819691272646*^9, 3.904819698109322*^9}, {
  3.906963650454173*^9, 3.906963650940193*^9}},
 CellLabel->
  "In[116]:=",ExpressionUUID->"b2e48c05-1c73-436f-9560-ed778b36ad97"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", GridBox[{
     {
      RowBox[{"x1", "\[Rule]", 
       FractionBox["627", "140"]}], 
      RowBox[{"x2", "\[Rule]", 
       FractionBox["487", "140"]}], 
      RowBox[{"x3", "\[Rule]", 
       FractionBox["277", "140"]}], 
      RowBox[{"x4", "\[Rule]", 
       FractionBox["131", "420"]}], 
      RowBox[{"x5", "\[Rule]", 
       RowBox[{"-", 
        FractionBox["151", "105"]}]}], 
      RowBox[{"x6", "\[Rule]", 
       RowBox[{"-", 
        FractionBox["68", "21"]}]}], 
      RowBox[{"x7", "\[Rule]", 
       RowBox[{"-", 
        FractionBox["71", "14"]}]}]}
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
   MatrixForm[BoxForm`e$]]]], "Output",
 CellChangeTimes->{
  3.9048172908150845`*^9, 3.904817429895508*^9, {3.9048176138113184`*^9, 
   3.9048176583010073`*^9}, 3.904819698456853*^9, {3.906964121192944*^9, 
   3.9069641309461136`*^9}, 3.9069642541285224`*^9, {3.9069650883582644`*^9, 
   3.9069651003196316`*^9}},
 CellLabel->
  "Out[117]//MatrixForm=",ExpressionUUID->"d266c375-1a6c-4911-9d14-\
4bfd0570891c"]
}, Open  ]],

Cell[CellGroupData[{

Cell[BoxData[
 RowBox[{
  RowBox[{"(*", 
   RowBox[{
   "\:041f\:043e\:0434\:0441\:0442\:0430\:0432\:0438\:043c", " ", 
    "\:0437\:043d\:0430\:0447\:0438\:043d\:0438\:044f"}], "*)"}], 
  "\[IndentingNewLine]", 
  RowBox[{
   RowBox[{
    RowBox[{"sol1", " ", "=", " ", 
     RowBox[{"X", "/.", 
      RowBox[{"Flatten", "[", "sol", "]"}]}]}], ";"}], "\[IndentingNewLine]", 
   RowBox[{"sol1", "//", "MatrixForm"}]}]}]], "Input",
 CellChangeTimes->{{3.904817694954793*^9, 3.9048177021849732`*^9}, {
  3.904817793274664*^9, 3.904817953894594*^9}, {3.9048197053713355`*^9, 
  3.904819718999487*^9}},
 CellLabel->
  "In[118]:=",ExpressionUUID->"4e91ca84-e563-4bd3-adc8-226c619e518e"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", GridBox[{
     {
      FractionBox["627", "140"]},
     {
      FractionBox["487", "140"]},
     {
      FractionBox["277", "140"]},
     {
      FractionBox["131", "420"]},
     {
      RowBox[{"-", 
       FractionBox["151", "105"]}]},
     {
      RowBox[{"-", 
       FractionBox["68", "21"]}]},
     {
      RowBox[{"-", 
       FractionBox["71", "14"]}]}
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
   MatrixForm[BoxForm`e$]]]], "Output",
 CellChangeTimes->{
  3.9048179249950542`*^9, {3.9048197128522396`*^9, 3.9048197197904625`*^9}, 
   3.906964134060995*^9, 3.906964254135522*^9, {3.9069650883628597`*^9, 
   3.9069651003507833`*^9}},
 CellLabel->
  "Out[119]//MatrixForm=",ExpressionUUID->"c14d6ef9-07c1-4065-93a4-\
09ee5d9b5645"]
}, Open  ]]
}, Open  ]],

Cell[CellGroupData[{

Cell["\<\
\:0432) \:0440\:0435\:0448\:0438\:0442\:044c \:0442\:0440\:0438 \:0432\:043e\
\:0437\:043c\:0443\:0449\:0435\:043d\:043d\:044b\:0435 \:0441\:0438\:0441\
\:0442\:0435\:043c\:044b, \:0443\:0432\:0435\:043b\:0438\:0447\:0438\:0432 \
\:0437\:043d\:0430\:0447\:0435\:043d\:0438\:0435
\:043f\:0440\:0430\:0432\:043e\:0439 \:0447\:0430\:0441\:0442\:0438 \:0442\
\:043e\:043b\:044c\:043a\:043e \:043f\:043e\:0441\:043b\:0435\:0434\:043d\
\:0435\:0433\:043e \:0443\:0440\:0430\:0432\:043d\:0435\:043d\:0438\:044f \
\:0441\:0438\:0441\:0442\:0435\:043c\:044b \:043f\:043e\:0441\:043b\:0435\
\:0434\:043e\:0432\:0430\:0442\:0435\:043b\:044c\:043d\:043e
\:043d\:0430 0,01%; 0,1% \:0438 \:043d\:0430 1%;\
\>", "Subsection",
 CellChangeTimes->{{3.906963694785554*^9, 
  3.9069637117721543`*^9}},ExpressionUUID->"70ae7b08-6a93-4e42-be19-\
258b30f3a8cd"],

Cell[CellGroupData[{

Cell[BoxData[
 RowBox[{
  RowBox[{"(*", 
   RowBox[{
   "\:0417\:0430\:0434\:0430\:0434\:0438\:043c", " ", 
    "\:0444\:0443\:043d\:043a\:0446\:0438\:044e", " ", 
    "\:0432\:043e\:0437\:043c\:0443\:0449\:0435\:043d\:0438\:044f"}], "*)"}], 
  "\[IndentingNewLine]", 
  RowBox[{
   RowBox[{
    RowBox[{
     RowBox[{"\[CapitalDelta]B", "[", "p_", "]"}], " ", "=", " ", 
     RowBox[{"{", 
      RowBox[{"0", ",", "0", ",", "0", ",", "0", ",", "0", ",", "0", ",", 
       RowBox[{
        RowBox[{"B", "[", 
         RowBox[{"[", "7", "]"}], "]"}], "*", 
        SuperscriptBox["0.1", "p"]}]}], "}"}]}], ";"}], "\n", 
   RowBox[{"(*", 
    RowBox[{
     RowBox[{
     "\:0420\:0435\:0448\:0438\:043c", " ", 
      "\:0432\:043e\:0437\:043c\:0443\:0449\:0435\:043d\:043d\:0443\:044e", 
      " ", 
      RowBox[{
      "\:0441\:0438\:0441\:0442\:0435\:043c\:0443", ".", " ", 
       "\:0420\:0435\:0448\:0435\:043d\:0438\:0435"}], " ", 
      "\:0437\:0430\:043f\:0438\:0448\:0435\:043c", " ", "\:0432", " ", 
      "\:0432\:0438\:0434\:0435", " ", 
      "\:043c\:0430\:0442\:0440\:0438\:0446\:044b"}], ",", " ", 
     RowBox[{
      RowBox[{
      "\:0433\:0434\:0435", " ", 
       "\:0441\:0442\:043e\:0440\:043e\:043a\:0430"}], " ", "-", " ", 
      RowBox[{
      "\:0440\:0435\:0448\:0435\:043d\:0438\:0435", " ", 
       "\:0441\:0438\:0441\:0442\:0435\:043c\:044b", " ", "\:0441", " ", 
       "\:043e\:043f\:0440\:0435\:0434\:0435\:043b\:0451\:043d\:043d\:044b\
\:043c", " ", 
       "\:0432\:043e\:0437\:043c\:0443\:0449\:0435\:043d\:0438\:0435\:043c"}]}\
]}], "*)"}], "\[IndentingNewLine]", 
   RowBox[{
    RowBox[{"sol2", "=", 
     RowBox[{"Table", "[", 
      RowBox[{
       RowBox[{"LinearSolve", "[", 
        RowBox[{"A", ",", 
         RowBox[{"B", "+", 
          RowBox[{"\[CapitalDelta]B", "[", "p", "]"}]}]}], "]"}], ",", " ", 
       RowBox[{"{", 
        RowBox[{"p", ",", "2", ",", "4", ",", "1"}], "}"}]}], "]"}]}], ";", 
    RowBox[{"sol2", "//", "MatrixForm"}]}]}]}]], "Input",
 CellChangeTimes->{{3.904820172338109*^9, 3.90482029249584*^9}, {
  3.906963742347967*^9, 3.9069637442954025`*^9}, {3.9069638408882623`*^9, 
  3.9069639798497252`*^9}},
 CellLabel->
  "In[120]:=",ExpressionUUID->"506d76d3-db38-48a1-ab47-0179b661d142"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", GridBox[{
     {"4.486904761904762`", "3.486904761904763`", "1.9869047619047617`", 
      "0.32023809523809527`", 
      RowBox[{"-", "1.4297619047619048`"}], 
      RowBox[{"-", "3.2297619047619044`"}], 
      RowBox[{"-", "5.121428571428572`"}]},
     {"4.479404761904762`", "3.479404761904762`", "1.979404761904762`", 
      "0.3127380952380951`", 
      RowBox[{"-", "1.4372619047619046`"}], 
      RowBox[{"-", "3.2372619047619047`"}], 
      RowBox[{"-", "5.076428571428571`"}]},
     {"4.478654761904761`", "3.478654761904761`", "1.978654761904762`", 
      "0.3119880952380953`", 
      RowBox[{"-", "1.4380119047619047`"}], 
      RowBox[{"-", "3.2380119047619047`"}], 
      RowBox[{"-", "5.071928571428572`"}]}
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
   MatrixForm[BoxForm`e$]]]], "Output",
 CellChangeTimes->{
  3.9069638567100844`*^9, {3.906963961510728*^9, 3.90696398205169*^9}, 
   3.9069642541585226`*^9, {3.906965088397904*^9, 3.90696510036639*^9}},
 CellLabel->
  "Out[121]//MatrixForm=",ExpressionUUID->"8fc3f0e2-3fb7-43dd-92aa-\
b13a59764bb3"]
}, Open  ]]
}, Open  ]],

Cell[CellGroupData[{

Cell["\<\
\:0433) \:043d\:0430\:0439\:0442\:0438 \:043f\:0440\:043e\:0433\:043d\:043e\
\:0437\:0438\:0440\:0443\:0435\:043c\:0443\:044e \:043f\:0440\:0435\:0434\
\:0435\:043b\:044c\:043d\:0443\:044e \:043e\:0442\:043d\:043e\:0441\:0438\
\:0442\:0435\:043b\:044c\:043d\:0443\:044e \:043f\:043e\:0433\:0440\:0435\
\:0448\:043d\:043e\:0441\:0442\:044c \:0440\:0435\:0448\:0435\:043d\:0438\:044f
\:043a\:0430\:0436\:0434\:043e\:0439 \:0432\:043e\:0437\:043c\:0443\:0449\
\:0435\:043d\:043d\:043e\:0439 \:0441\:0438\:0441\:0442\:0435\:043c\:044b\
\>", "Subsection",
 CellChangeTimes->{
  3.906964002951104*^9},ExpressionUUID->"3b55b8d5-405c-44fb-a50f-\
30499d06753d"],

Cell[CellGroupData[{

Cell[BoxData[
 RowBox[{
  RowBox[{"(*", 
   RowBox[{
   "\:0412\:044b\:0447\:0438\:0441\:043b\:0438\:043c", " ", 
    "\:0430\:0431\:0441\:043e\:043b\:044e\:0442\:043d\:0443\:044e", " ", 
    "\:043f\:043e\:0433\:0440\:0435\:0448\:043d\:043e\:0441\:0442\:044c"}], 
   "*)"}], "\[IndentingNewLine]", 
  RowBox[{
   RowBox[{
    RowBox[{"\[CapitalDelta]X", "=", 
     RowBox[{"Table", "[", 
      RowBox[{
       RowBox[{
        RowBox[{"Norm", "[", 
         RowBox[{
          RowBox[{"sol2", "[", 
           RowBox[{"[", "p", "]"}], "]"}], "-", "sol1"}], "]"}], " ", "//", 
        "N"}], ",", " ", 
       RowBox[{"{", 
        RowBox[{"p", ",", "1", ",", "3", ",", "1"}], "}"}]}], "]"}]}], ";"}], 
   "\[IndentingNewLine]", 
   RowBox[{"\[CapitalDelta]X", "//", "MatrixForm"}]}]}]], "Input",
 CellChangeTimes->{{3.9048206272944555`*^9, 3.9048206540244427`*^9}, {
  3.9048207902011795`*^9, 3.904821079734313*^9}, {3.9048211689445934`*^9, 
  3.904821263510044*^9}, {3.9048218716423244`*^9, 3.904821874588321*^9}},
 CellLabel->
  "In[122]:=",ExpressionUUID->"5e673827-b4d3-4e86-b901-8b8527662bcb"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", 
   TagBox[GridBox[{
      {"0.05400617248673305`"},
      {"0.005400617248673161`"},
      {"0.0005400617248676991`"}
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
 CellChangeTimes->{{3.9048211901044445`*^9, 3.9048212647188125`*^9}, 
   3.904821900050268*^9, 3.906964105372972*^9, 3.906964144147008*^9, 
   3.9069642541785216`*^9, {3.906965072094204*^9, 3.906965100388565*^9}},
 CellLabel->
  "Out[123]//MatrixForm=",ExpressionUUID->"4dd88280-b747-4db1-b0fc-\
30bd9ea06983"]
}, Open  ]],

Cell[CellGroupData[{

Cell[BoxData[
 RowBox[{
  RowBox[{"(*", 
   RowBox[{
   "\:0412\:044b\:0447\:0438\:0441\:043b\:0438\:043c", " ", 
    "\:043f\:0440\:043e\:0433\:043d\:043e\:0437\:0438\:0440\:0443\:0435\:043c\
\:0443\:044e", " ", 
    "\:043f\:0440\:0435\:0434\:0435\:043b\:044c\:043d\:0443\:044e", " ", 
    "\:043e\:0442\:043d\:043e\:0441\:0438\:0442\:0435\:043b\:044c\:043d\:0443\
\:044e", " ", 
    "\:043f\:043e\:0433\:0440\:0435\:0448\:043d\:043e\:0441\:0442\:044c"}], 
   "*)"}], "\[IndentingNewLine]", 
  RowBox[{
   RowBox[{
    RowBox[{
     SubscriptBox["\[Delta]", "X"], "=", 
     RowBox[{"Table", "[", 
      RowBox[{
       RowBox[{
        RowBox[{"(", 
         RowBox[{"condA", "*", 
          FractionBox[
           RowBox[{"Norm", "[", 
            RowBox[{"\[CapitalDelta]B", "[", "p", "]"}], "]"}], 
           RowBox[{"Norm", "[", 
            RowBox[{"B", "+", 
             RowBox[{"\[CapitalDelta]B", "[", "p", "]"}]}], "]"}]]}], ")"}], "//",
         " ", "PercentForm"}], ",", 
       RowBox[{"{", 
        RowBox[{"p", ",", "2", ",", "4", ",", "1"}], "}"}]}], "]"}]}], ";"}], 
   "\[IndentingNewLine]", 
   RowBox[{
    SubscriptBox["\[Delta]", "X"], "//", "MatrixForm"}]}]}]], "Input",
 CellChangeTimes->{{3.9048199004472*^9, 3.9048199285615873`*^9}, 
   3.904819978347228*^9, {3.904820023812504*^9, 3.904820057319338*^9}, {
   3.904820094713258*^9, 3.9048201528425426`*^9}, {3.904820328973796*^9, 
   3.904820499784412*^9}, 3.904820532755375*^9, {3.904820689826395*^9, 
   3.9048207219246655`*^9}, {3.9048213620036554`*^9, 
   3.9048214872892365`*^9}, {3.904821758744486*^9, 3.904821791387273*^9}, {
   3.9048218547341175`*^9, 3.904821892883602*^9}, {3.9069649191770477`*^9, 
   3.9069650128177953`*^9}, {3.9069650935118923`*^9, 3.906965096321974*^9}},
 CellLabel->
  "In[124]:=",ExpressionUUID->"79c29857-762a-42ff-ab92-a20050f72836"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", 
   TagBox[GridBox[{
      {
       TagBox[
        InterpretationBox[
         StyleBox["\<\"18.98%\"\>",
          ShowStringCharacters->False],
         0.1898310128007867,
         AutoDelete->True],
        PercentForm]},
      {
       TagBox[
        InterpretationBox[
         StyleBox["\<\"1.908%\"\>",
          ShowStringCharacters->False],
         0.019082931367930635`,
         AutoDelete->True],
        PercentForm]},
      {
       TagBox[
        InterpretationBox[
         StyleBox["\<\"0.1909%\"\>",
          ShowStringCharacters->False],
         0.0019092951616936462`,
         AutoDelete->True],
        PercentForm]}
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
 CellChangeTimes->{3.906965100404227*^9},
 CellLabel->
  "Out[125]//MatrixForm=",ExpressionUUID->"f774e970-7109-412e-8273-\
810e12902a47"]
}, Open  ]]
}, Open  ]],

Cell[CellGroupData[{

Cell["\<\
\:0434) \:043d\:0430\:0439\:0442\:0438 \:043e\:0442\:043d\:043e\:0441\:0438\
\:0442\:0435\:043b\:044c\:043d\:0443\:044e \:043f\:043e\:0433\:0440\:0435\
\:0448\:043d\:043e\:0441\:0442\:044c \:0440\:0435\:0448\:0435\:043d\:0438\
\:044f \:043a\:0430\:0436\:0434\:043e\:0439 \:0432\:043e\:0437\:043c\:0443\
\:0449\:0435\:043d\:043d\:043e\:0439 \:0441\:0438\:0441\:0442\:0435\:043c\
\:044b;
\:0441\:0434\:0435\:043b\:0430\:0442\:044c \:0432\:044b\:0432\:043e\:0434 \
\:043e \:0437\:0430\:0432\:0438\:0441\:0438\:043c\:043e\:0441\:0442\:0438 \
\:043e\:0442\:043d\:043e\:0441\:0438\:0442\:0435\:043b\:044c\:043d\:043e\:0439\
 \:043f\:043e\:0433\:0440\:0435\:0448\:043d\:043e\:0441\:0442\:0438 \:043e\
\:0442 \:0432\:0435\:043b\:0438\:0447\:0438\:043d\:044b
\:0432\:043e\:0437\:043c\:0443\:0449\:0435\:043d\:0438\:044f \:0438 \:0447\
\:0438\:0441\:043b\:0430 \:043e\:0431\:0443\:0441\:043b\:043e\:0432\:043b\
\:0435\:043d\:043d\:043e\:0441\:0442\:0438 \:043c\:0430\:0442\:0440\:0438\
\:0446\:044b A .\
\>", "Subsection",
 CellChangeTimes->{{3.9069640853574314`*^9, 
  3.906964087469249*^9}},ExpressionUUID->"221907ab-bc0d-4e05-9d61-\
b1e42e4cf644"],

Cell[CellGroupData[{

Cell[BoxData[
 RowBox[{
  RowBox[{"(*", 
   RowBox[{
   "\:0412\:044b\:0447\:0438\:0441\:043b\:0438\:043c", " ", 
    "\:043e\:0442\:043d\:043e\:0441\:0438\:0442\:0435\:043b\:044c\:043d\:0443\
\:044e", " ", 
    "\:043f\:043e\:0433\:0440\:0435\:0448\:043d\:043e\:0441\:0442\:044c"}], 
   "*)"}], "\[IndentingNewLine]", 
  RowBox[{
   RowBox[{
    RowBox[{"\[CurlyEpsilon]", "=", 
     RowBox[{"Table", "[", 
      RowBox[{
       RowBox[{
        FractionBox[
         RowBox[{"\[CapitalDelta]X", "[", 
          RowBox[{"[", "p", "]"}], "]"}], 
         RowBox[{"Norm", "[", 
          RowBox[{"sol2", "[", 
           RowBox[{"[", "p", "]"}], "]"}], "]"}]], " ", "//", " ", 
        "PercentForm"}], ",", 
       RowBox[{"{", 
        RowBox[{"p", ",", "1", ",", "3", ",", "1"}], "}"}]}], "]"}]}], ";"}], 
   "\[IndentingNewLine]", 
   RowBox[{"\[CurlyEpsilon]", "//", "MatrixForm"}]}]}]], "Input",
 CellChangeTimes->{{3.9048213124423733`*^9, 3.9048213202537007`*^9}, {
  3.904821546757318*^9, 3.9048215497083225`*^9}, {3.9048216167388573`*^9, 
  3.9048216320534625`*^9}, {3.9048216665542483`*^9, 3.9048217347451043`*^9}, {
  3.9069648976386003`*^9, 3.906964908942874*^9}},
 CellLabel->
  "In[126]:=",ExpressionUUID->"1a46a1eb-8c83-4a97-85db-749af0f49d61"],

Cell[BoxData[
 TagBox[
  RowBox[{"(", "\[NoBreak]", 
   TagBox[GridBox[{
      {
       TagBox[
        InterpretationBox[
         StyleBox["\<\"0.6234%\"\>",
          ShowStringCharacters->False],
         0.006234193516227635,
         AutoDelete->True],
        PercentForm]},
      {
       TagBox[
        InterpretationBox[
         StyleBox["\<\"0.06257%\"\>",
          ShowStringCharacters->False],
         0.000625686594397945,
         AutoDelete->True],
        PercentForm]},
      {
       TagBox[
        InterpretationBox[
         StyleBox["\<\"0.006259%\"\>",
          ShowStringCharacters->False],
         0.00006259135892303921,
         AutoDelete->True],
        PercentForm]}
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
 CellChangeTimes->{
  3.9048217368910217`*^9, 3.9048220144259768`*^9, 3.9069642542055235`*^9, 
   3.9069649104637628`*^9, {3.9069650884327545`*^9, 3.906965100432682*^9}},
 CellLabel->
  "Out[127]//MatrixForm=",ExpressionUUID->"67a18125-54e3-4db2-9b6f-\
7e6a9d7ad97e"]
}, Open  ]]
}, Open  ]]
}, Open  ]]
},
WindowSize->{1152, 585.6},
WindowMargins->{{
  Automatic, -5.399999999999864}, {-5.399999999999977, Automatic}},
PrintingCopies->1,
PrintingPageRange->{Automatic, Automatic},
PrintingOptions->{"Magnification"->1.,
"PaperOrientation"->"Portrait",
"PaperSize"->{595.2755905511812, 841.8897637795276}},
Magnification:>1. Inherited,
FrontEndVersion->"13.3 for Microsoft Windows (64-bit) (July 24, 2023)",
StyleDefinitions->"Default.nb",
ExpressionUUID->"6712b707-013a-4b75-b28c-b800e3b37258"
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
Cell[1510, 35, 248, 4, 98, "Title",ExpressionUUID->"046d3c4c-88d4-47a7-835d-2e3a362b76a6"],
Cell[1761, 41, 297, 5, 53, "Subtitle",ExpressionUUID->"78f3ad62-952d-4eb4-809c-3b3153d84216"],
Cell[CellGroupData[{
Cell[2083, 50, 1708, 40, 97, "Input",ExpressionUUID->"436f2075-44db-4973-97ba-a0b70f22ee5f"],
Cell[3794, 92, 1060, 27, 145, "Output",ExpressionUUID->"ab7317f3-e9db-436e-8750-a8dd9df07b72"]
}, Open  ]],
Cell[CellGroupData[{
Cell[4891, 124, 1028, 28, 116, "Input",ExpressionUUID->"52f22b8e-8c78-4441-bb23-de208cea72de"],
Cell[5922, 154, 996, 34, 145, "Output",ExpressionUUID->"b0f97da6-0d41-47d7-b6ad-fa1a950a257e"]
}, Open  ]],
Cell[CellGroupData[{
Cell[6955, 193, 1118, 27, 81, "Input",ExpressionUUID->"6a70395b-8962-483c-bbef-8afe1b33d867"],
Cell[8076, 222, 879, 27, 145, "Output",ExpressionUUID->"c70b0f87-1160-46d5-874f-91ec28c021ad"]
}, Open  ]],
Cell[CellGroupData[{
Cell[8992, 254, 452, 7, 54, "Subsection",ExpressionUUID->"6f0e3deb-e73d-46f1-bc84-ffc659383b26"],
Cell[CellGroupData[{
Cell[9469, 265, 809, 17, 43, "Input",ExpressionUUID->"502a9aee-e08b-47df-94a8-64c5877856b2"],
Cell[10281, 284, 358, 6, 32, "Output",ExpressionUUID->"daf97b43-7072-4c3a-a205-58968b07161e"]
}, Open  ]]
}, Open  ]],
Cell[CellGroupData[{
Cell[10688, 296, 437, 7, 54, "Subsection",ExpressionUUID->"a1b0e069-378c-42cd-833d-4b70eea3c783"],
Cell[CellGroupData[{
Cell[11150, 307, 881, 19, 78, "Input",ExpressionUUID->"b2e48c05-1c73-436f-9560-ed778b36ad97"],
Cell[12034, 328, 1378, 39, 52, "Output",ExpressionUUID->"d266c375-1a6c-4911-9d14-4bfd0570891c"]
}, Open  ]],
Cell[CellGroupData[{
Cell[13449, 372, 681, 17, 97, "Input",ExpressionUUID->"4e91ca84-e563-4bd3-adc8-226c619e518e"],
Cell[14133, 391, 1096, 37, 200, "Output",ExpressionUUID->"c14d6ef9-07c1-4065-93a4-09ee5d9b5645"]
}, Open  ]]
}, Open  ]],
Cell[CellGroupData[{
Cell[15278, 434, 848, 14, 108, "Subsection",ExpressionUUID->"70ae7b08-6a93-4e42-be19-258b30f3a8cd"],
Cell[CellGroupData[{
Cell[16151, 452, 2260, 56, 138, "Input",ExpressionUUID->"506d76d3-db38-48a1-ab47-0179b661d142"],
Cell[18414, 510, 1423, 34, 78, "Output",ExpressionUUID->"8fc3f0e2-3fb7-43dd-92aa-b13a59764bb3"]
}, Open  ]]
}, Open  ]],
Cell[CellGroupData[{
Cell[19886, 550, 662, 11, 81, "Subsection",ExpressionUUID->"3b55b8d5-405c-44fb-a50f-30499d06753d"],
Cell[CellGroupData[{
Cell[20573, 565, 1099, 27, 97, "Input",ExpressionUUID->"5e673827-b4d3-4e86-b901-8b8527662bcb"],
Cell[21675, 594, 906, 24, 78, "Output",ExpressionUUID->"4dd88280-b747-4db1-b0fc-30bd9ea06983"]
}, Open  ]],
Cell[CellGroupData[{
Cell[22618, 623, 1850, 42, 119, "Input",ExpressionUUID->"79c29857-762a-42ff-ab92-a20050f72836"],
Cell[24471, 667, 1261, 43, 78, "Output",ExpressionUUID->"f774e970-7109-412e-8273-810e12902a47"]
}, Open  ]]
}, Open  ]],
Cell[CellGroupData[{
Cell[25781, 716, 1150, 19, 108, "Subsection",ExpressionUUID->"221907ab-bc0d-4e05-9d61-b1e42e4cf644"],
Cell[CellGroupData[{
Cell[26956, 739, 1258, 31, 119, "Input",ExpressionUUID->"1a46a1eb-8c83-4a97-85db-749af0f49d61"],
Cell[28217, 772, 1396, 45, 101, "Output",ExpressionUUID->"67a18125-54e3-4db2-9b6f-7e6a9d7ad97e"]
}, Open  ]]
}, Open  ]]
}, Open  ]]
}
]
*)

(* NotebookSignature Ww0yzliTBSwKTAK5DF@WCmEg *)
