ΩP
MC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Program.cs
	namespace 	
MTOGO
 
; 
public

 
class

 
Program

 
{ 
public 

static 
void 
Main 
( 
string "
[" #
]# $
args% )
)) *
{ 
var 
builder 
= 
WebApplication $
.$ %
CreateBuilder% 2
(2 3
args3 7
)7 8
;8 9
builder 
. 
Services 
. 
	Configure "
<" #
ApiSettings# .
>. /
(/ 0
builder0 7
.7 8
Configuration8 E
.E F

GetSectionF P
(P Q
$strQ ^
)^ _
)_ `
;` a
builder 
. 
Services 
. 
AddHttpClient &
<& '

UserFacade' 1
>1 2
(2 3
client3 9
=>: <
{ 	
client 
. 
BaseAddress 
=  
new! $
Uri% (
(( )
builder) 0
.0 1
Configuration1 >
[> ?
$str? T
]T U
)U V
;V W
} 	
)	 

;
 
builder 
. 
Services 
. 
AddSingleton %
<% &
IUserInterface& 4
>4 5
(5 6
sp6 8
=>9 ;
sp< >
.> ?
GetRequiredService? Q
<Q R

UserFacadeR \
>\ ]
(] ^
)^ _
)_ `
;` a
builder 
. 
Services 
. 
AddHttpClient &
<& '
OrderFacade' 2
>2 3
(3 4
client4 :
=>; =
{ 	
client 
. 
BaseAddress 
=  
new! $
Uri% (
(( )
builder) 0
.0 1
Configuration1 >
[> ?
$str? U
]U V
)V W
;W X
} 	
)	 

;
 
builder 
. 
Services 
. 
AddSingleton %
<% &
IOrderInterface& 5
>5 6
(6 7
sp7 9
=>: <
sp= ?
.? @
GetRequiredService@ R
<R S
OrderFacadeS ^
>^ _
(_ `
)` a
)a b
;b c
builder"" 
."" 
Services"" 
."" 
AddHttpClient"" &
<""& '
FeedbackFacade""' 5
>""5 6
(""6 7
client""7 =
=>""> @
{## 	
client$$ 
.$$ 
BaseAddress$$ 
=$$  
new$$! $
Uri$$% (
($$( )
builder$$) 0
.$$0 1
Configuration$$1 >
[$$> ?
$str$$? X
]$$X Y
)$$Y Z
;$$Z [
}%% 	
)%%	 

;%%
 
builder&& 
.&& 
Services&& 
.&& 
AddSingleton&& %
<&&% &
IFeedbackInterface&&& 8
>&&8 9
(&&9 :
sp&&: <
=>&&= ?
sp&&@ B
.&&B C
GetRequiredService&&C U
<&&U V
FeedbackFacade&&V d
>&&d e
(&&e f
)&&f g
)&&g h
;&&h i
builder)) 
.)) 
Services)) 
.)) 
AddHttpClient)) &
<))& '
PaymentFacade))' 4
>))4 5
())5 6
client))6 <
=>))= ?
{** 	
client++ 
.++ 
BaseAddress++ 
=++  
new++! $
Uri++% (
(++( )
builder++) 0
.++0 1
Configuration++1 >
[++> ?
$str++? W
]++W X
)++X Y
;++Y Z
},, 	
),,	 

;,,
 
builder-- 
.-- 
Services-- 
.-- 
AddSingleton-- %
<--% &
IPaymentInterface--& 7
>--7 8
(--8 9
sp--9 ;
=>--< >
sp--? A
.--A B
GetRequiredService--B T
<--T U
PaymentFacade--U b
>--b c
(--c d
)--d e
)--e f
;--f g
builder00 
.00 
Services00 
.00 
AddHttpClient00 &
<00& '
AgentFacade00' 2
>002 3
(003 4
client004 :
=>00; =
{11 	
client22 
.22 
BaseAddress22 
=22  
new22! $
Uri22% (
(22( )
builder22) 0
.220 1
Configuration221 >
[22> ?
$str22? U
]22U V
)22V W
;22W X
}33 	
)33	 

;33
 
builder44 
.44 
Services44 
.44 
AddSingleton44 %
<44% &
IAgentInterface44& 5
>445 6
(446 7
sp447 9
=>44: <
sp44= ?
.44? @
GetRequiredService44@ R
<44R S
AgentFacade44S ^
>44^ _
(44_ `
)44` a
)44a b
;44b c
builder77 
.77 
Services77 
.77 
AddHttpClient77 &
<77& '
CustomerFacade77' 5
>775 6
(776 7
client777 =
=>77> @
{88 	
var99 
baseAddress99 
=99 
builder99 %
.99% &
Configuration99& 3
[993 4
$str994 M
]99M N
;99N O
client:: 
.:: 
BaseAddress:: 
=::  
new::! $
Uri::% (
(::( )
baseAddress::) 4
)::4 5
;::5 6
};; 	
);;	 

;;;
 
builder<< 
.<< 
Services<< 
.<< 
AddSingleton<< %
<<<% &
ICustomerInterface<<& 8
><<8 9
(<<9 :
sp<<: <
=><<= ?
sp<<@ B
.<<B C
GetRequiredService<<C U
<<<U V
CustomerFacade<<V d
><<d e
(<<e f
)<<f g
)<<g h
;<<h i
builder?? 
.?? 
Services?? 
.?? 
AddHttpClient?? &
<??& '
RestaurantFacade??' 7
>??7 8
(??8 9
client??9 ?
=>??@ B
{@@ 	
clientAA 
.AA 
BaseAddressAA 
=AA  
newAA! $
UriAA% (
(AA( )
builderAA) 0
.AA0 1
ConfigurationAA1 >
[AA> ?
$strAA? S
]AAS T
)AAT U
;AAU V
}BB 	
)BB	 

;BB
 
builderCC 
.CC 
ServicesCC 
.CC 
AddSingletonCC %
<CC% & 
IRestaurantInterfaceCC& :
>CC: ;
(CC; <
spCC< >
=>CC? A
spCCB D
.CCD E
GetRequiredServiceCCE W
<CCW X
RestaurantFacadeCCX h
>CCh i
(CCi j
)CCj k
)CCk l
;CCl m
builderGG 
.GG 
ServicesGG 
.GG 
AddSingletonGG %
<GG% &
IFacadeFactoryGG& 4
,GG4 5
FacadeFactoryGG6 C
>GGC D
(GGD E
)GGE F
;GGF G
builderJJ 
.JJ 
ServicesJJ 
.JJ 
AddControllersJJ '
(JJ' (
)JJ( )
;JJ) *
builderMM 
.MM 
ServicesMM 
.MM #
AddEndpointsApiExplorerMM 0
(MM0 1
)MM1 2
;MM2 3
builderNN 
.NN 
ServicesNN 
.NN 
AddSwaggerGenNN &
(NN& '
)NN' (
;NN( )
builderQQ 
.QQ 
ServicesQQ 
.QQ 
AddCorsQQ  
(QQ  !
optionsQQ! (
=>QQ) +
{RR 	
optionsSS 
.SS 
	AddPolicySS 
(SS 
$strSS (
,SS( )
policySS* 0
=>SS1 3
{TT 
policyUU 
.UU 
AllowAnyOriginUU %
(UU% &
)UU& '
.VV 
AllowAnyMethodVV #
(VV# $
)VV$ %
.WW 
AllowAnyHeaderWW #
(WW# $
)WW$ %
;WW% &
}XX 
)XX 
;XX 
}YY 	
)YY	 

;YY
 
var[[ 
app[[ 
=[[ 
builder[[ 
.[[ 
Build[[ 
([[  
)[[  !
;[[! "
if__ 

(__ 
app__ 
.__ 
Environment__ 
.__ 
IsDevelopment__ )
(__) *
)__* +
)__+ ,
{`` 	
appaa 
.aa 

UseSwaggeraa 
(aa 
)aa 
;aa 
appbb 
.bb 
UseSwaggerUIbb 
(bb 
cbb 
=>bb !
cbb" #
.bb# $
SwaggerEndpointbb$ 3
(bb3 4
$strbb4 N
,bbN O
$strbbP [
)bb[ \
)bb\ ]
;bb] ^
}cc 	
appdd 
.dd 

UseRoutingdd 
(dd 
)dd 
;dd 
appee 
.ee 
UseMetricServeree 
(ee 
)ee 
;ee 
appff 
.ff 
UseHttpMetricsff 
(ff 
)ff 
;ff 
apphh 
.hh 
UseCorshh 
(hh 
$strhh 
)hh 
;hh  
appii 
.ii 
UseAuthorizationii 
(ii 
)ii 
;ii 
appjj 
.jj 
MapControllersjj 
(jj 
)jj 
;jj 
appll 
.ll 
Runll 
(ll 
)ll 
;ll 
}mm 
}nn â
_C:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Interfaces\IUserInterface.cs
	namespace 	
MTOGO
 
. 

Interfaces 
; 
public 
	interface 
IUserInterface 
{ 
Task 
< 	
UserDTO	 
> 
LoginUserAsync  
(  !
UserDTO! (
user) -
)- .
;. /
Task 
< 	
UserDTO	 
> 
CreateUserAsync !
(! "
UserDTO" )
user* .
). /
;/ 0
}		 ø
eC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Interfaces\IRestaurantInterface.cs
	namespace 	
MTOGO
 
. 

Interfaces 
{ 
public 

	interface  
IRestaurantInterface )
{		 
Task

 
<

 
List

 
<

 
RestaurantDTO

 
>

  
>

  !
GetRestaurants

" 0
(

0 1
)

1 2
;

2 3
Task 
< 
RestaurantDTO 
> 
GetRestaurant )
() *
int* -
id. 0
)0 1
;1 2
Task 
< 
RestaurantDTO 
> 
CreateRestaurant ,
(, -
RestaurantDTO- :

restaurant; E
)E F
;F G
Task 
< 
RestaurantDTO 
> 
UpdateRestaurant ,
(, -
RestaurantDTO- :

restaurant; E
)E F
;F G
Task 
< 
MenuItemDTO 
> 
CreateMenuItem (
(( )
MenuItemDTO) 4
menuItem5 =
)= >
;> ?
Task 
< 
MenuItemDTO 
> 
UpdateMenuItem (
(( )
MenuItemDTO) 4
menuItem5 =
)= >
;> ?
Task 
< 
List 
< 
MenuItemDTO 
> 
> 
GetMenuItems  ,
(, -
int- 0
id1 3
)3 4
;4 5
Task "
UpdateRestaurantRating #
(# $
UpdateRatingDTO$ 3
	ratingDto4 =
)= >
;> ?
} 
} §
bC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Interfaces\IPaymentInterface.cs
	namespace 	
MTOGO
 
. 

Interfaces 
; 
public 
	interface 
IPaymentInterface "
{ 
Task 
< 	

PaymentDTO	 
> 
GetPaymentById #
(# $
int$ '
id( *
)* +
;+ ,
Task		 
<		 	

PaymentDTO			 
>		 
CreatePayment		 "
(		" #
PaymentRequestDto		# 4
paymentRequestDto		5 F
)		F G
;		G H
}

 Œ
`C:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Interfaces\IOrderInterface.cs
	namespace 	
MTOGO
 
. 

Interfaces 
; 
public 
	interface 
IOrderInterface  
{ 
Task 
< 	
string	 
> 
GetAllOrders 
( 
) 
;  
Task		 
<		 	
string			 
>		 
GetOrder		 
(		 
int		 
id		  
)		  !
;		! "
Task

 
<

 	
OrderDTO

	 
>

 
CreateOrder

 
(

 
OrderDTO

 '
orderDto

( 0
)

0 1
;

1 2
Task 
< 	
OrderDTO	 
> 
UpdateOrderStatus $
($ %
UpdateStatusDTO% 4
orderDto5 =
)= >
;> ?
Task 
< 	
List	 
< 
OrderDTO 
> 
> 
GetOrdersByStatus *
(* +
string+ 1
status2 8
)8 9
;9 :
Task 
< 	
OrderDTO	 
> 
UpdateOrder 
( 
UpdateOrderIdsDTO 0
dto1 4
)4 5
;5 6
Task 
< 	
List	 
< 
OrderDTO 
> 
> 
GetOrdersByAgentId +
(+ ,
int, /
agentId0 7
)7 8
;8 9
Task 
< 	
List	 
< 
OrderDTO 
> 
> !
GetOrdersByCustomerID .
(. /
int/ 2

customerId3 =
)= >
;> ?
} Í
cC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Interfaces\IFeedbackInterface.cs
	namespace 	
MTOGO
 
. 

Interfaces 
; 
public 
	interface 
IFeedbackInterface #
{ 
Task 
< 
FeedbackDTO 
> 
CreateFeedback #
(# $
FeedbackDTO$ /
feedbackDto0 ;
); <
;< =
}		 ö
cC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Interfaces\ICustomerInterface.cs
	namespace 	
MTOGO
 
. 

Interfaces 
; 
public 
	interface 
ICustomerInterface #
{ 
Task 
< 	
CustomerDTO	 
> 
CreateCustomer $
($ %
CustomerDTO% 0
customerDto1 <
)< =
;= >
Task		 
<		 	
CustomerDTO			 
>		 
GetCustomer		 !
(		! "
int		" %
id		& (
)		( )
;		) *
}

 î
`C:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Interfaces\IAgentInterface.cs
	namespace 	
MTOGO
 
. 

Interfaces 
; 
public 
	interface 
IAgentInterface  
{		 
Task

 
<

 	
AgentDTO

	 
>

 
CreateAgent

 
(

 
AgentDTO

 '
agentDto

( 0
)

0 1
;

1 2
Task 
< 	
AgentDTO	 
> 
GetAgent 
( 
int 
id  "
)" #
;# $
Task 
UpdateAgentRating	 
( 
UpdateRatingDTO *
	ratingDto+ 4
)4 5
;5 6
} à
^C:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Factories\IFacadeFactory.cs
	namespace 	
MTOGO
 
. 
	Factories 
{ 
public 

	interface 
IFacadeFactory #
{ 
IUserInterface 
GetUserFacade $
($ %
)% &
;& '
IOrderInterface 
GetOrderFacade &
(& '
)' (
;( )
IFeedbackInterface		 
GetFeedbackFacade		 ,
(		, -
)		- .
;		. /
IPaymentInterface

 
GetPaymentFacade

 *
(

* +
)

+ ,
;

, -
IAgentInterface 
GetAgentFacade &
(& '
)' (
;( )
ICustomerInterface 
GetCustomerFacade ,
(, -
)- .
;. / 
IRestaurantInterface 
GetResFacade )
() *
)* +
;+ ,
} 
} ë
]C:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Factories\FacadeFactory.cs
	namespace 	
MTOGO
 
. 
	Factories 
; 
public 
class 
FacadeFactory 
: 
IFacadeFactory +
{ 
private 
readonly 
IServiceProvider %
_serviceProvider& 6
;6 7
public		 

FacadeFactory		 
(		 
IServiceProvider		 )
serviceProvider		* 9
)		9 :
{

 
_serviceProvider 
= 
serviceProvider *
;* +
} 
public 

IUserInterface 
GetUserFacade '
(' (
)( )
{ 
return 
_serviceProvider 
.  
GetRequiredService  2
<2 3
IUserInterface3 A
>A B
(B C
)C D
;D E
} 
public 

IOrderInterface 
GetOrderFacade )
() *
)* +
{ 
return 
_serviceProvider 
.  
GetRequiredService  2
<2 3
IOrderInterface3 B
>B C
(C D
)D E
;E F
} 
public 

IFeedbackInterface 
GetFeedbackFacade /
(/ 0
)0 1
{ 
return 
_serviceProvider 
.  
GetRequiredService  2
<2 3
IFeedbackInterface3 E
>E F
(F G
)G H
;H I
} 
public 

IPaymentInterface 
GetPaymentFacade -
(- .
). /
{ 
return 
_serviceProvider 
.  
GetRequiredService  2
<2 3
IPaymentInterface3 D
>D E
(E F
)F G
;G H
}   
public"" 

IAgentInterface"" 
GetAgentFacade"" )
("") *
)""* +
{## 
return$$ 
_serviceProvider$$ 
.$$  
GetRequiredService$$  2
<$$2 3
IAgentInterface$$3 B
>$$B C
($$C D
)$$D E
;$$E F
}%% 
public'' 

ICustomerInterface'' 
GetCustomerFacade'' /
(''/ 0
)''0 1
{(( 
return)) 
_serviceProvider)) 
.))  
GetRequiredService))  2
<))2 3
ICustomerInterface))3 E
>))E F
())F G
)))G H
;))H I
}** 
public,, 
 
IRestaurantInterface,, 
GetResFacade,,  ,
(,,, -
),,- .
{-- 
return.. 
_serviceProvider.. 
...  
GetRequiredService..  2
<..2 3 
IRestaurantInterface..3 G
>..G H
(..H I
)..I J
;..J K
}// 
}22 æ
XC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Facades\UserFacade.cs
	namespace 	
MTOGO
 
. 
Facades 
; 
public 
class 

UserFacade 
: 

BaseFacade $
,$ %
IUserInterface& 4
{ 
public 


UserFacade 
( 

HttpClient  

httpClient! +
)+ ,
:- .
base/ 3
(3 4

httpClient4 >
)> ?
{@ A
}B C
public

 

async

 
Task

 
<

 
UserDTO

 
>

 
LoginUserAsync

 -
(

- .
UserDTO

. 5
user

6 :
)

: ;
{ 
var 
response 
= 
await 
_httpClient (
.( )
PostAsJsonAsync) 8
(8 9
$str9 @
,@ A
userB F
)F G
;G H
response 
. #
EnsureSuccessStatusCode (
(( )
)) *
;* +
return 
await 
response 
. 
Content %
.% &
ReadFromJsonAsync& 7
<7 8
UserDTO8 ?
>? @
(@ A
)A B
??C E
throwF K
newL O%
InvalidOperationExceptionP i
(i j
)j k
;k l
} 
public 

async 
Task 
< 
UserDTO 
> 
CreateUserAsync .
(. /
UserDTO/ 6
user7 ;
); <
{ 
var 
response 
= 
await 
_httpClient (
.( )
PostAsJsonAsync) 8
(8 9
$str9 ;
,; <
user= A
)A B
;B C
response 
. #
EnsureSuccessStatusCode (
(( )
)) *
;* +
return 
await 
response 
. 
Content %
.% &
ReadFromJsonAsync& 7
<7 8
UserDTO8 ?
>? @
(@ A
)A B
??C E
throwF K
newL O%
InvalidOperationExceptionP i
(i j
)j k
;k l
} 
} úY
^C:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Facades\RestaurantFacade.cs
	namespace

 	
MTOGO


 
.

 
Facades

 
{ 
public 

class 
RestaurantFacade !
:" #

BaseFacade$ .
,. / 
IRestaurantInterface0 D
{ 
public 
RestaurantFacade 
(  

HttpClient  *

httpClient+ 5
)5 6
:7 8
base9 =
(= >

httpClient> H
)H I
{J K
}L M
public 
async 
Task 
< 
List 
< 
RestaurantDTO ,
>, -
>- .
GetRestaurants/ =
(= >
)> ?
{ 	
try 
{ 
var 
response 
= 
await $
_httpClient% 0
.0 1
GetAsync1 9
(9 :
$str: <
)< =
;= >
response 
. #
EnsureSuccessStatusCode 0
(0 1
)1 2
;2 3
var 
restaurants 
=  !
await" '
response( 0
.0 1
Content1 8
.8 9
ReadFromJsonAsync9 J
<J K
ListK O
<O P
RestaurantDTOP ]
>] ^
>^ _
(_ `
)` a
;a b
return 
restaurants "
;" #
} 
catch 
( 
	Exception 
e 
) 
{ 
Console 
. 
	WriteLine !
(! "
$"" $
$str$ @
{@ A
eA B
}B C
"C D
)D E
;E F
throw 
; 
} 
} 	
public   
async   
Task   
<   
RestaurantDTO   '
>  ' (
GetRestaurant  ) 6
(  6 7
int  7 :
id  ; =
)  = >
{!! 	
try"" 
{## 
var$$ 
response$$ 
=$$ 
await$$ $
_httpClient$$% 0
.$$0 1
GetAsync$$1 9
($$9 :
$"$$: <
{$$< =
id$$= ?
}$$? @
"$$@ A
)$$A B
;$$B C
response%% 
.%% #
EnsureSuccessStatusCode%% 0
(%%0 1
)%%1 2
;%%2 3
var&& 

restaurant&& 
=&&  
await&&! &
response&&' /
.&&/ 0
Content&&0 7
.&&7 8
ReadFromJsonAsync&&8 I
<&&I J
RestaurantDTO&&J W
>&&W X
(&&X Y
)&&Y Z
;&&Z [
return'' 

restaurant'' !
;''! "
}(( 
catch)) 
()) 
	Exception)) 
e)) 
))) 
{** 
Console++ 
.++ 
	WriteLine++ !
(++! "
$"++" $
$str++$ F
{++F G
id++G I
}++I J
$str++J L
{++L M
e++M N
}++N O
"++O P
)++P Q
;++Q R
throw,, 
;,, 
}-- 
}.. 	
public00 
async00 
Task00 
<00 
RestaurantDTO00 '
>00' (
CreateRestaurant00) 9
(009 :
RestaurantDTO00: G

restaurant00H R
)00R S
{11 	
try22 
{33 
var44 
response44 
=44 
await44 $
_httpClient44% 0
.440 1
PostAsJsonAsync441 @
(44@ A
$str44A C
,44C D

restaurant44E O
)44O P
;44P Q
response55 
.55 #
EnsureSuccessStatusCode55 0
(550 1
)551 2
;552 3
var66 
createdRestaurant66 %
=66& '
await66( -
response66. 6
.666 7
Content667 >
.66> ?
ReadFromJsonAsync66? P
<66P Q
RestaurantDTO66Q ^
>66^ _
(66_ `
)66` a
;66a b
return77 
createdRestaurant77 (
;77( )
}88 
catch99 
(99 
	Exception99 
e99 
)99 
{:: 
Console;; 
.;; 
	WriteLine;; !
(;;! "
$";;" $
$str;;$ ?
{;;? @
e;;@ A
};;A B
";;B C
);;C D
;;;D E
throw<< 
;<< 
}== 
}>> 	
public@@ 
async@@ 
Task@@ 
<@@ 
RestaurantDTO@@ '
>@@' (
UpdateRestaurant@@) 9
(@@9 :
RestaurantDTO@@: G

restaurant@@H R
)@@R S
{AA 	
tryBB 
{CC 
varDD 
responseDD 
=DD 
awaitDD $
_httpClientDD% 0
.DD0 1
PutAsJsonAsyncDD1 ?
(DD? @
$strDD@ B
,DDB C

restaurantDDD N
)DDN O
;DDO P
responseEE 
.EE #
EnsureSuccessStatusCodeEE 0
(EE0 1
)EE1 2
;EE2 3
varFF 
updatedRestaurantFF %
=FF& '
awaitFF( -
responseFF. 6
.FF6 7
ContentFF7 >
.FF> ?
ReadFromJsonAsyncFF? P
<FFP Q
RestaurantDTOFFQ ^
>FF^ _
(FF_ `
)FF` a
;FFa b
returnGG 
updatedRestaurantGG (
;GG( )
}HH 
catchII 
(II 
	ExceptionII 
eII 
)II 
{JJ 
ConsoleKK 
.KK 
	WriteLineKK !
(KK! "
$"KK" $
$strKK$ ?
{KK? @
eKK@ A
}KKA B
"KKB C
)KKC D
;KKD E
throwLL 
;LL 
}MM 
}NN 	
publicPP 
asyncPP 
TaskPP 
<PP 
MenuItemDTOPP %
>PP% &
CreateMenuItemPP' 5
(PP5 6
MenuItemDTOPP6 A
menuItemPPB J
)PPJ K
{QQ 	
tryRR 
{SS 
varTT 
responseTT 
=TT 
awaitTT $
_httpClientTT% 0
.TT0 1
PostAsJsonAsyncTT1 @
(TT@ A
$strTTA K
,TTK L
menuItemTTM U
)TTU V
;TTV W
responseUU 
.UU #
EnsureSuccessStatusCodeUU 0
(UU0 1
)UU1 2
;UU2 3
varVV 
createdMenuItemVV #
=VV$ %
awaitVV& +
responseVV, 4
.VV4 5
ContentVV5 <
.VV< =
ReadFromJsonAsyncVV= N
<VVN O
MenuItemDTOVVO Z
>VVZ [
(VV[ \
)VV\ ]
;VV] ^
returnWW 
createdMenuItemWW &
;WW& '
}XX 
catchYY 
(YY 
	ExceptionYY 
eYY 
)YY 
{ZZ 
Console[[ 
.[[ 
	WriteLine[[ !
([[! "
$"[[" $
$str[[$ >
{[[> ?
e[[? @
}[[@ A
"[[A B
)[[B C
;[[C D
throw\\ 
;\\ 
}]] 
}^^ 	
public`` 
async`` 
Task`` 
<`` 
MenuItemDTO`` %
>``% &
UpdateMenuItem``' 5
(``5 6
MenuItemDTO``6 A
menuItem``B J
)``J K
{aa 	
trybb 
{cc 
vardd 
responsedd 
=dd 
awaitdd $
_httpClientdd% 0
.dd0 1
PutAsJsonAsyncdd1 ?
(dd? @
$strdd@ J
,ddJ K
menuItemddL T
)ddT U
;ddU V
responseee 
.ee #
EnsureSuccessStatusCodeee 0
(ee0 1
)ee1 2
;ee2 3
varff 
updatedMenuItemff #
=ff$ %
awaitff& +
responseff, 4
.ff4 5
Contentff5 <
.ff< =
ReadFromJsonAsyncff= N
<ffN O
MenuItemDTOffO Z
>ffZ [
(ff[ \
)ff\ ]
;ff] ^
returngg 
updatedMenuItemgg &
;gg& '
}hh 
catchii 
(ii 
	Exceptionii 
eii 
)ii 
{jj 
Consolekk 
.kk 
	WriteLinekk !
(kk! "
$"kk" $
$strkk$ >
{kk> ?
ekk? @
}kk@ A
"kkA B
)kkB C
;kkC D
throwll 
;ll 
}mm 
}nn 	
publicpp 
asyncpp 
Taskpp 
<pp 
Listpp 
<pp 
MenuItemDTOpp *
>pp* +
>pp+ ,
GetMenuItemspp- 9
(pp9 :
intpp: =
idpp> @
)pp@ A
{qq 	
tryrr 
{ss 
vartt 
responsett 
=tt 
awaittt $
_httpClienttt% 0
.tt0 1
GetAsynctt1 9
(tt9 :
$"tt: <
$strtt< F
{ttF G
idttG I
}ttI J
"ttJ K
)ttK L
;ttL M
responseuu 
.uu #
EnsureSuccessStatusCodeuu 0
(uu0 1
)uu1 2
;uu2 3
varvv 
	menuItemsvv 
=vv 
awaitvv  %
responsevv& .
.vv. /
Contentvv/ 6
.vv6 7
ReadFromJsonAsyncvv7 H
<vvH I
ListvvI M
<vvM N
MenuItemDTOvvN Y
>vvY Z
>vvZ [
(vv[ \
)vv\ ]
;vv] ^
returnww 
	menuItemsww  
;ww  !
}xx 
catchyy 
(yy 
	Exceptionyy 
eyy 
)yy 
{zz 
Console{{ 
.{{ 
	WriteLine{{ !
({{! "
$"{{" $
$str{{$ P
{{{P Q
id{{Q S
}{{S T
$str{{T V
{{{V W
e{{W X
}{{X Y
"{{Y Z
){{Z [
;{{[ \
throw|| 
;|| 
}}} 
}~~ 	
public
ÄÄ 
async
ÄÄ 
Task
ÄÄ $
UpdateRestaurantRating
ÄÄ 0
(
ÄÄ0 1
UpdateRatingDTO
ÄÄ1 @
	ratingDto
ÄÄA J
)
ÄÄJ K
{
ÅÅ 	
try
ÇÇ 
{
ÉÉ 
var
ÑÑ 
response
ÑÑ 
=
ÑÑ 
await
ÑÑ $
_httpClient
ÑÑ% 0
.
ÑÑ0 1
PutAsJsonAsync
ÑÑ1 ?
(
ÑÑ? @
$str
ÑÑ@ H
,
ÑÑH I
	ratingDto
ÑÑJ S
)
ÑÑS T
;
ÑÑT U
response
ÖÖ 
.
ÖÖ %
EnsureSuccessStatusCode
ÖÖ 0
(
ÖÖ0 1
)
ÖÖ1 2
;
ÖÖ2 3
}
ÜÜ 
catch
áá 
(
áá 
	Exception
áá 
e
áá 
)
áá 
{
àà 
Console
ââ 
.
ââ 
	WriteLine
ââ !
(
ââ! "
$"
ââ" $
$str
ââ$ F
{
ââF G
e
ââG H
}
ââH I
"
ââI J
)
ââJ K
;
ââK L
throw
ää 
;
ää 
}
ãã 
}
åå 	
}
çç 
}éé Æ
[C:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Facades\PaymentFacade.cs
	namespace 	
MTOGO
 
. 
Facades 
{ 
public 

class 
PaymentFacade 
:  

BaseFacade! +
,+ ,
IPaymentInterface- >
{ 
public		 
PaymentFacade		 
(		 

HttpClient		 '

httpClient		( 2
)		2 3
:		4 5
base		6 :
(		: ;

httpClient		; E
)		E F
{		G H
}		I J
public 
async 
Task 
< 

PaymentDTO $
>$ %
GetPaymentById& 4
(4 5
int5 8
id9 ;
); <
{ 	
try 
{ 
var 
response 
= 
await $
_httpClient% 0
.0 1
GetAsync1 9
(9 :
$": <
{< =
id= ?
}? @
"@ A
)A B
;B C
response 
. #
EnsureSuccessStatusCode 0
(0 1
)1 2
;2 3
var 
payment 
= 
await #
response$ ,
., -
Content- 4
.4 5
ReadFromJsonAsync5 F
<F G

PaymentDTOG Q
>Q R
(R S
)S T
;T U
return 
payment 
; 
} 
catch 
( 
	Exception 
e 
) 
{ 
Console 
. 
	WriteLine !
(! "
$"" $
$str$ C
{C D
idD F
}F G
$strG I
{I J
eJ K
}K L
"L M
)M N
;N O
throw 
; 
} 
} 	
public 
async 
Task 
< 

PaymentDTO $
>$ %
CreatePayment& 3
(3 4
PaymentRequestDto4 E
paymentRequestDtoF W
)W X
{ 	
try 
{ 
var 
response 
= 
await $
_httpClient% 0
.0 1
PostAsJsonAsync1 @
(@ A
$strA C
,C D
paymentRequestDtoE V
)V W
;W X
response   
.   #
EnsureSuccessStatusCode   0
(  0 1
)  1 2
;  2 3
var!! 
payment!! 
=!! 
await!! #
response!!$ ,
.!!, -
Content!!- 4
.!!4 5
ReadFromJsonAsync!!5 F
<!!F G

PaymentDTO!!G Q
>!!Q R
(!!R S
)!!S T
;!!T U
return"" 
payment"" 
;"" 
}## 
catch$$ 
($$ 
	Exception$$ 
e$$ 
)$$ 
{%% 
Console&& 
.&& 
	WriteLine&& !
(&&! "
$"&&" $
$str&&$ <
{&&< =
e&&= >
}&&> ?
"&&? @
)&&@ A
;&&A B
throw'' 
;'' 
}(( 
})) 	
}** 
}++ Ä;
YC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Facades\OrderFacade.cs
	namespace 	
MTOGO
 
. 
Facades 
{ 
public 

class 
OrderFacade 
: 

BaseFacade )
,) *
IOrderInterface+ :
{		 
public

 
OrderFacade

 
(

 

HttpClient

 %

httpClient

& 0
)

0 1
:

2 3
base

4 8
(

8 9

httpClient

9 C
)

C D
{

E F
}

G H
public 
async 
Task 
< 
string  
>  !
GetAllOrders" .
(. /
)/ 0
{ 	
var 
response 
= 
await  
_httpClient! ,
., -
GetAsync- 5
(5 6
$str6 8
)8 9
;9 :
response 
. #
EnsureSuccessStatusCode ,
(, -
)- .
;. /
return 
await 
response !
.! "
Content" )
.) *
ReadAsStringAsync* ;
(; <
)< =
;= >
} 	
public 
async 
Task 
< 
string  
>  !
GetOrder" *
(* +
int+ .
id/ 1
)1 2
{ 	
var 
response 
= 
await  
_httpClient! ,
., -
GetAsync- 5
(5 6
$"6 8
{8 9
id9 ;
}; <
"< =
)= >
;> ?
response 
. #
EnsureSuccessStatusCode ,
(, -
)- .
;. /
return 
await 
response !
.! "
Content" )
.) *
ReadAsStringAsync* ;
(; <
)< =
;= >
} 	
public 
async 
Task 
< 
OrderDTO "
>" #
CreateOrder$ /
(/ 0
OrderDTO0 8
orderDto9 A
)A B
{ 	
var 
response 
= 
await  
_httpClient! ,
., -
PostAsJsonAsync- <
(< =
$str= ?
,? @
orderDtoA I
)I J
;J K
response 
. #
EnsureSuccessStatusCode ,
(, -
)- .
;. /
return 
await 
response !
.! "
Content" )
.) *
ReadFromJsonAsync* ;
<; <
OrderDTO< D
>D E
(E F
)F G
;G H
} 	
public!! 
async!! 
Task!! 
<!! 
OrderDTO!! "
>!!" #
UpdateOrderStatus!!$ 5
(!!5 6
UpdateStatusDTO!!6 E
orderDto!!F N
)!!N O
{"" 	
var## 
response## 
=## 
await##  
_httpClient##! ,
.##, -
PutAsJsonAsync##- ;
(##; <
$str##< >
,##> ?
orderDto##@ H
)##H I
;##I J
response$$ 
.$$ #
EnsureSuccessStatusCode$$ ,
($$, -
)$$- .
;$$. /
return%% 
await%% 
response%% !
.%%! "
Content%%" )
.%%) *
ReadFromJsonAsync%%* ;
<%%; <
OrderDTO%%< D
>%%D E
(%%E F
)%%F G
;%%G H
}&& 	
public(( 
async(( 
Task(( 
<(( 
List(( 
<(( 
OrderDTO(( '
>((' (
>((( )
GetOrdersByStatus((* ;
(((; <
string((< B
status((C I
)((I J
{)) 	
var** 
response** 
=** 
await**  
_httpClient**! ,
.**, -
GetAsync**- 5
(**5 6
$"**6 8
$str**8 ?
{**? @
status**@ F
}**F G
"**G H
)**H I
;**I J
response++ 
.++ #
EnsureSuccessStatusCode++ ,
(++, -
)++- .
;++. /
return,, 
await,, 
response,, !
.,,! "
Content,," )
.,,) *
ReadFromJsonAsync,,* ;
<,,; <
List,,< @
<,,@ A
OrderDTO,,A I
>,,I J
>,,J K
(,,K L
),,L M
;,,M N
}-- 	
public// 
async// 
Task// 
<// 
OrderDTO// "
>//" #
UpdateOrder//$ /
(/// 0
UpdateOrderIdsDTO//0 A
dto//B E
)//E F
{00 	
var11 
response11 
=11 
await11  
_httpClient11! ,
.11, -
PutAsJsonAsync11- ;
(11; <
$str11< G
,11G H
dto11I L
)11L M
;11M N
response22 
.22 #
EnsureSuccessStatusCode22 ,
(22, -
)22- .
;22. /
return33 
await33 
response33 !
.33! "
Content33" )
.33) *
ReadFromJsonAsync33* ;
<33; <
OrderDTO33< D
>33D E
(33E F
)33F G
;33G H
}44 	
public66 
async66 
Task66 
<66 
List66 
<66 
OrderDTO66 '
>66' (
>66( )
GetOrdersByAgentId66* <
(66< =
int66= @
agentId66A H
)66H I
{77 	
var88 
response88 
=88 
await88  
_httpClient88! ,
.88, -
GetAsync88- 5
(885 6
$"886 8
$str888 >
{88> ?
agentId88? F
}88F G
"88G H
)88H I
;88I J
response99 
.99 #
EnsureSuccessStatusCode99 ,
(99, -
)99- .
;99. /
return:: 
await:: 
response:: !
.::! "
Content::" )
.::) *
ReadFromJsonAsync::* ;
<::; <
List::< @
<::@ A
OrderDTO::A I
>::I J
>::J K
(::K L
)::L M
;::M N
};; 	
public== 
async== 
Task== 
<== 
List== 
<== 
OrderDTO== '
>==' (
>==( )!
GetOrdersByCustomerID==* ?
(==? @
int==@ C

customerId==D N
)==N O
{>> 	
var?? 
response?? 
=?? 
await??  
_httpClient??! ,
.??, -
GetAsync??- 5
(??5 6
$"??6 8
$str??8 A
{??A B

customerId??B L
}??L M
"??M N
)??N O
;??O P
response@@ 
.@@ #
EnsureSuccessStatusCode@@ ,
(@@, -
)@@- .
;@@. /
returnAA 
awaitAA 
responseAA !
.AA! "
ContentAA" )
.AA) *
ReadFromJsonAsyncAA* ;
<AA; <
ListAA< @
<AA@ A
OrderDTOAAA I
>AAI J
>AAJ K
(AAK L
)AAL M
;AAM N
}BB 	
}CC 
}DD ÜI
\C:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Facades\FeedbackFacade.cs
	namespace 	
MTOGO
 
. 
Facades 
{ 
public 

class 
FeedbackFacade 
:  !

BaseFacade" ,
,, -
IFeedbackInterface. @
{		 
private

 
readonly

 
IOrderInterface

 (
_orderFacade

) 5
;

5 6
private 
readonly 
IAgentInterface (
_agentFacade) 5
;5 6
private 
readonly  
IRestaurantInterface -
_restaurantFacade. ?
;? @
public 
FeedbackFacade 
( 

HttpClient 

httpClient !
,! "
IOrderInterface 
orderFacade '
,' (
IAgentInterface 
agentFacade '
,' ( 
IRestaurantInterface  
restaurantFacade! 1
)1 2
: 
base 
( 

httpClient 
) 
{ 	
_orderFacade 
= 
orderFacade &
;& '
_agentFacade 
= 
agentFacade &
;& '
_restaurantFacade 
= 
restaurantFacade  0
;0 1
} 	
public 
async 
Task 
< 
FeedbackDTO %
>% &
CreateFeedback' 5
(5 6
FeedbackDTO6 A
feedbackDtoB M
)M N
{ 	
FeedbackDTO 
createdFeedback '
=( )
null* .
;. /
try 
{ 
var   
response   
=   
await   $
_httpClient  % 0
.  0 1
PostAsJsonAsync  1 @
(  @ A
$str  A C
,  C D
feedbackDto  E P
)  P Q
;  Q R
response!! 
.!! #
EnsureSuccessStatusCode!! 0
(!!0 1
)!!1 2
;!!2 3
createdFeedback"" 
=""  !
await""" '
response""( 0
.""0 1
Content""1 8
.""8 9
ReadFromJsonAsync""9 J
<""J K
FeedbackDTO""K V
>""V W
(""W X
)""X Y
;""Y Z
}## 
catch$$ 
($$ 
	Exception$$ 
e$$ 
)$$ 
{%% 
Console&& 
.&& 
	WriteLine&& !
(&&! "
$"&&" $
$str&&$ =
{&&= >
e&&> ?
}&&? @
"&&@ A
)&&A B
;&&B C
throw'' 
;'' 
}(( 
try** 
{++ 
List,, 
<,, 
FeedbackDTO,,  
>,,  !
agentFeedbacks,," 0
=,,1 2
await,,3 8!
GetFeedbacksByAgentId,,9 N
(,,N O
createdFeedback,,O ^
.,,^ _
OrderDTO,,_ g
.,,g h
AgentId,,h o
),,o p
;,,p q
List-- 
<-- 
FeedbackDTO--  
>--  !
restaurantFeedbacks--" 5
=--6 7
await--8 =&
GetFeedbacksByRestaurantId--> X
(--X Y
createdFeedback--Y h
.--h i
OrderDTO--i q
.--q r
RestaurantId--r ~
)--~ 
;	-- Ä
UpdateRatingDTO// 
agentRatingDto//  .
=/// 0
new//1 4
UpdateRatingDTO//5 D
(//D E
feedbackDto00 
.00  
OrderDTO00  (
.00( )
AgentId00) 0
,000 1
agentFeedbacks11 "
.11" #
Average11# *
(11* +
feedback11+ 3
=>114 6
feedback117 ?
.11? @
Agentrating11@ K
)11K L
,11L M
agentFeedbacks22 "
.22" #
Count22# (
)33 
;33 
UpdateRatingDTO55 
restaurantRatingDto55  3
=554 5
new556 9
UpdateRatingDTO55: I
(55I J
feedbackDto66 
.66  
OrderDTO66  (
.66( )
RestaurantId66) 5
,665 6
restaurantFeedbacks77 '
.77' (
Average77( /
(77/ 0
feedback770 8
=>779 ;
feedback77< D
.77D E
RestaurantRating77E U
)77U V
,77V W
restaurantFeedbacks88 '
.88' (
Count88( -
)99 
;99 
await;; 
_agentFacade;; "
.;;" #
UpdateAgentRating;;# 4
(;;4 5
agentRatingDto;;5 C
);;C D
;;;D E
await<< 
_restaurantFacade<< '
.<<' ("
UpdateRestaurantRating<<( >
(<<> ?
restaurantRatingDto<<? R
)<<R S
;<<S T
}>> 
catch?? 
(?? 
	Exception?? 
e?? 
)?? 
{@@ 
ConsoleAA 
.AA 
	WriteLineAA !
(AA! "
$"AA" $
$strAA$ <
{AA< =
eAA= >
}AA> ?
"AA? @
)AA@ A
;AAA B
throwBB 
;BB 
}CC 
tryEE 
{FF 
UpdateStatusDTOGG 
updateStatusDtoGG  /
=GG0 1
newGG2 5
UpdateStatusDTOGG6 E
(GGE F
createdFeedbackGGF U
.GGU V
OrderDTOGGV ^
.GG^ _
IdGG_ a
,GGa b
$strGGc n
)GGn o
;GGo p
awaitHH 
_orderFacadeHH "
.HH" #
UpdateOrderStatusHH# 4
(HH4 5
updateStatusDtoHH5 D
)HHD E
;HHE F
}JJ 
catchKK 
(KK 
	ExceptionKK 
eKK 
)KK 
{LL 
ConsoleMM 
.MM 
	WriteLineMM !
(MM! "
$"MM" $
$strMM$ A
{MMA B
eMMB C
}MMC D
"MMD E
)MME F
;MMF G
throwNN 
;NN 
}OO 
returnQQ 
createdFeedbackQQ "
;QQ" #
}RR 	
publicUU 
asyncUU 
TaskUU 
<UU 
ListUU 
<UU 
FeedbackDTOUU *
>UU* +
>UU+ ,!
GetFeedbacksByAgentIdUU- B
(UUB C
intUUC F
agentIdUUG N
)UUN O
{VV 	
tryWW 
{XX 
varYY 
responseYY 
=YY 
awaitYY $
_httpClientYY% 0
.YY0 1
GetAsyncYY1 9
(YY9 :
$"YY: <
$strYY< B
{YYB C
agentIdYYC J
}YYJ K
"YYK L
)YYL M
;YYM N
responseZZ 
.ZZ #
EnsureSuccessStatusCodeZZ 0
(ZZ0 1
)ZZ1 2
;ZZ2 3
var[[ 
	feedbacks[[ 
=[[ 
await[[  %
response[[& .
.[[. /
Content[[/ 6
.[[6 7
ReadFromJsonAsync[[7 H
<[[H I
List[[I M
<[[M N
FeedbackDTO[[N Y
>[[Y Z
>[[Z [
([[[ \
)[[\ ]
;[[] ^
return\\ 
	feedbacks\\  
;\\  !
}]] 
catch^^ 
(^^ 
	Exception^^ 
e^^ 
)^^ 
{__ 
Console`` 
.`` 
	WriteLine`` !
(``! "
$"``" $
$str``$ I
{``I J
agentId``J Q
}``Q R
$str``R T
{``T U
e``U V
}``V W
"``W X
)``X Y
;``Y Z
throwaa 
;aa 
}bb 
}cc 	
privateff 
asyncff 
Taskff 
<ff 
Listff 
<ff  
FeedbackDTOff  +
>ff+ ,
>ff, -&
GetFeedbacksByRestaurantIdff. H
(ffH I
intffI L
restaurantIdffM Y
)ffY Z
{gg 	
tryhh 
{ii 
varjj 
responsejj 
=jj 
awaitjj $
_httpClientjj% 0
.jj0 1
GetAsyncjj1 9
(jj9 :
$"jj: <
$strjj< G
{jjG H
restaurantIdjjH T
}jjT U
"jjU V
)jjV W
;jjW X
responsekk 
.kk #
EnsureSuccessStatusCodekk 0
(kk0 1
)kk1 2
;kk2 3
varll 
	feedbacksll 
=ll 
awaitll  %
responsell& .
.ll. /
Contentll/ 6
.ll6 7
ReadFromJsonAsyncll7 H
<llH I
ListllI M
<llM N
FeedbackDTOllN Y
>llY Z
>llZ [
(ll[ \
)ll\ ]
;ll] ^
returnmm 
	feedbacksmm  
;mm  !
}nn 
catchoo 
(oo 
	Exceptionoo 
eoo 
)oo 
{pp 
Consoleqq 
.qq 
	WriteLineqq !
(qq! "
$"qq" $
$strqq$ N
{qqN O
restaurantIdqqO [
}qq[ \
$strqq\ ^
{qq^ _
eqq_ `
}qq` a
"qqa b
)qqb c
;qqc d
throwrr 
;rr 
}ss 
}tt 	
}uu 
}vv ®
\C:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Facades\CustomerFacade.cs
	namespace 	
MTOGO
 
. 
Facades 
{ 
public		 

class		 
CustomerFacade		 
:		  !

BaseFacade		" ,
,		, -
ICustomerInterface		. @
{

 
public 
CustomerFacade 
( 

HttpClient (

httpClient) 3
)3 4
:5 6
base7 ;
(; <

httpClient< F
)F G
{H I
}J K
public 
async 
Task 
< 
CustomerDTO %
>% &
CreateCustomer' 5
(5 6
CustomerDTO6 A
customerDtoB M
)M N
{ 	
var 
response 
= 
await  
_httpClient! ,
., -
PostAsJsonAsync- <
(< =
$str= ?
,? @
customerDtoA L
)L M
;M N
response 
. #
EnsureSuccessStatusCode ,
(, -
)- .
;. /
var 
createdCustomer 
=  !
await" '
response( 0
.0 1
Content1 8
.8 9
ReadFromJsonAsync9 J
<J K
CustomerDTOK V
>V W
(W X
)X Y
;Y Z
return 
createdCustomer "
;" #
} 	
public 
async 
Task 
< 
CustomerDTO %
>% &
GetCustomer' 2
(2 3
int3 6
id7 9
)9 :
{ 	
try 
{ 
var 
response 
= 
await $
_httpClient% 0
.0 1
GetAsync1 9
(9 :
$": <
{< =
id= ?
}? @
"@ A
)A B
;B C
response 
. #
EnsureSuccessStatusCode 0
(0 1
)1 2
;2 3
var 
customer 
= 
await $
response% -
.- .
Content. 5
.5 6
ReadFromJsonAsync6 G
<G H
CustomerDTOH S
>S T
(T U
)U V
;V W
return 
customer 
;  
} 
catch 
( 
	Exception 
e 
) 
{   
Console!! 
.!! 
	WriteLine!! !
(!!! "
$"!!" $
$str!!$ D
{!!D E
id!!E G
}!!G H
$str!!H J
{!!J K
e!!K L
}!!L M
"!!M N
)!!N O
;!!O P
throw"" 
;"" 
}## 
}$$ 	
}'' 
}(( ˘
XC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Facades\BaseFacade.cs
	namespace 	
MTOGO
 
. 
Facades 
; 
public 
abstract 
class 

BaseFacade  
{ 
	protected 
readonly 

HttpClient !
_httpClient" -
;- .
	protected 

BaseFacade 
( 

HttpClient #

httpClient$ .
). /
{ 
_httpClient		 
=		 

httpClient		  
;		  !
}

 
} æ!
YC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Facades\AgentFacade.cs
	namespace		 	
MTOGO		
 
.		 
Facades		 
{

 
public 

class 
AgentFacade 
: 

BaseFacade )
,) *
IAgentInterface+ :
{ 
public 
AgentFacade 
( 

HttpClient %

httpClient& 0
)0 1
:2 3
base4 8
(8 9

httpClient9 C
)C D
{E F
}G H
public 
async 
Task 
< 
AgentDTO "
>" #
CreateAgent$ /
(/ 0
AgentDTO0 8
agentDto9 A
)A B
{ 	
try 
{ 
var 
response 
= 
await $
_httpClient% 0
.0 1
PostAsJsonAsync1 @
(@ A
$strA C
,C D
agentDtoE M
)M N
;N O
response 
. #
EnsureSuccessStatusCode 0
(0 1
)1 2
;2 3
var 
createdAgent  
=! "
await# (
response) 1
.1 2
Content2 9
.9 :
ReadFromJsonAsync: K
<K L
AgentDTOL T
>T U
(U V
)V W
;W X
return 
createdAgent #
;# $
} 
catch 
( 
	Exception 
e 
) 
{ 
Console 
. 
	WriteLine !
(! "
$"" $
$str$ :
{: ;
e; <
}< =
"= >
)> ?
;? @
throw 
; 
} 
} 	
public 
async 
Task 
< 
AgentDTO "
>" #
GetAgent$ ,
(, -
int- 0
id1 3
)3 4
{   	
try!! 
{"" 
var## 
response## 
=## 
await## $
_httpClient##% 0
.##0 1
GetAsync##1 9
(##9 :
$"##: <
{##< =
id##= ?
}##? @
"##@ A
)##A B
;##B C
response$$ 
.$$ #
EnsureSuccessStatusCode$$ 0
($$0 1
)$$1 2
;$$2 3
var%% 
agent%% 
=%% 
await%% !
response%%" *
.%%* +
Content%%+ 2
.%%2 3
ReadFromJsonAsync%%3 D
<%%D E
AgentDTO%%E M
>%%M N
(%%N O
)%%O P
;%%P Q
return&& 
agent&& 
;&& 
}'' 
catch(( 
((( 
	Exception(( 
e(( 
)(( 
{)) 
Console** 
.** 
	WriteLine** !
(**! "
$"**" $
$str**$ C
{**C D
id**D F
}**F G
$str**G I
{**I J
e**J K
}**K L
"**L M
)**M N
;**N O
throw++ 
;++ 
},, 
}-- 	
public// 
async// 
Task// 
UpdateAgentRating// +
(//+ ,
UpdateRatingDTO//, ;
	ratingDto//< E
)//E F
{00 	
try11 
{22 
var33 
response33 
=33 
await33 $
_httpClient33% 0
.330 1
PutAsJsonAsync331 ?
(33? @
$str33@ H
,33H I
	ratingDto33J S
)33S T
;33T U
response44 
.44 #
EnsureSuccessStatusCode44 0
(440 1
)441 2
;442 3
}55 
catch66 
(66 
	Exception66 
e66 
)66 
{77 
Console88 
.88 
	WriteLine88 !
(88! "
$"88" $
$str88$ A
{88A B
e88B C
}88C D
"88D E
)88E F
;88F G
throw99 
;99 
}:: 
};; 	
}<< 
}== ì
ZC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\UserDTO\UserDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
. 
UserDTO 
; 
public 
class 
UserDTO 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

string 
Email 
{ 
get 
; 
set "
;" #
}$ %
public 

string 
Password 
{ 
get  
;  !
set" %
;% &
}' (
public 

int 
? 
RestaurantId 
{ 
get "
;" #
set$ '
;' (
}) *
public		 

int		 
?		 
AgentId		 
{		 
get		 
;		 
set		 "
;		" #
}		$ %
public

 

int

 
?

 

CustomerId

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
public 

int 
? 
	ManagerId 
{ 
get 
;  
set! $
;$ %
}& '
public 

UserDTO 
( 
int 
id 
, 
string !
email" '
,' (
string) /
password0 8
,8 9
int: =
restaurantId> J
,J K
intL O
agentIdP W
,W X
intY \

customerId] g
,g h
inti l
	managerIdm v
)v w
{ 
Id 

= 
id 
; 
Email 
= 
email 
; 
Password 
= 
password 
; 
RestaurantId 
= 
restaurantId #
;# $
AgentId 
= 
agentId 
; 

CustomerId 
= 

customerId 
;  
	ManagerId 
= 
	managerId 
; 
} 
public 

UserDTO 
( 
int 
id 
, 
string !
email" '
,' (
string) /
password0 8
)8 9
{ 
Id 

= 
id 
; 
Email 
= 
email 
; 
Password 
= 
password 
; 
} 
public 

UserDTO 
( 
) 
{   
}!! 
}## ˘
gC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\RestaurantDTOs\RestaurantDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
. 
RestaurantDTOs #
;# $
public 
class 
RestaurantDTO 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

String 
Name 
{ 
get 
; 
set !
;! "
}# $
public 


AddressDTO 
Address 
{ 
get  #
;# $
set% (
;( )
}* +
public 

List 
< 
MenuItemDTO 
> 
? 
	MenuItems '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public		 

double		 
Rating		 
{		 
get		 
;		 
set		  #
;		# $
}		% &
public

 

int

 
NumberOfRatings

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
public 

String 
CuisineType 
{ 
get  #
;# $
set% (
;( )
}* +
public 

String 
Description 
{ 
get  #
;# $
set% (
;( )
}* +
public 

String 
PhoneNumber 
{ 
get  #
;# $
set% (
;( )
}* +
public 

RestaurantDTO 
( 
int 
id 
,  
String! '
name( ,
,, -

AddressDTO. 8
address9 @
,@ A
doubleB H
ratingI O
,O P
intQ T
numberOfRatingsU d
,d e
Stringf l
cuisineTypem x
,x y
String	z Ä
description
Å å
,
å ç
String
é î
phoneNumber
ï †
)
† °
{ 
Id 

= 
id 
; 
Name 
= 
name 
; 
Address 
= 
address 
; 
Rating 
= 
rating 
; 
NumberOfRatings 
= 
numberOfRatings )
;) *
CuisineType 
= 
cuisineType !
;! "
Description 
= 
description !
;! "
PhoneNumber 
= 
phoneNumber !
;! "
} 
public 

RestaurantDTO 
( 
) 
{ 
} 
} Ø
eC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\RestaurantDTOs\MenuItemDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
. 
RestaurantDTOs #
;# $
public 
class 
MenuItemDTO 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

String 
ItemName 
{ 
get  
;  !
set" %
;% &
}' (
public 

double 
Price 
{ 
get 
; 
set  #
;# $
}% &
public 

String 
ItemDescription !
{" #
get$ '
;' (
set) ,
;, -
}. /
public		 

int		 
RestaurantId		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public

 

string

 
Image

 
{

 
get

 
;

 
set

 "
;

" #
}

$ %
public 

MenuItemDTO 
( 
int 
id 
, 
String %
itemName& .
,. /
double0 6
price7 <
,< =
String> D
itemDescriptionE T
,T U
intV Y
restaurantIdZ f
,f g
stringh n
imageo t
)t u
{ 
Id 

= 
id 
; 
ItemName 
= 
itemName 
; 
Price 
= 
price 
; 
ItemDescription 
= 
itemDescription )
;) *
RestaurantId 
= 
restaurantId #
;# $
Image 
= 
image 
; 
} 
public 

MenuItemDTO 
( 
) 
{ 
} 
} §
dC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\RestaurantDTOs\AddressDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
. 
RestaurantDTOs #
;# $
public 
class 

AddressDTO 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

String 
Street 
{ 
get 
; 
set  #
;# $
}% &
public		 

String		 
City		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
public

 

String

 
ZipCode

 
{

 
get

 
;

 
set

  #
;

# $
}

% &
public 

String 
Region 
{ 
get 
; 
set  #
;# $
}% &
public 


AddressDTO 
( 
int 
id 
, 
String $
street% +
,+ ,
String- 3
city4 8
,8 9
String: @
zipCodeA H
,H I
StringJ P
regionQ W
)W X
{ 
Id 

= 
id 
; 
Street 
= 
street 
; 
City 
= 
city 
; 
ZipCode 
= 
zipCode 
; 
Region 
= 
region 
; 
} 
public 


AddressDTO 
( 
) 
{ 
} 
public 


AddressDTO 
( 
String 
street #
,# $
String% +
city, 0
,0 1
String2 8
zipCode9 @
,@ A
StringB H
regionI O
)O P
{ 
Street 
= 
street 
; 
City   
=   
city   
;   
ZipCode!! 
=!! 
zipCode!! 
;!! 
Region"" 
="" 
region"" 
;"" 
}## 
}$$  
hC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\PaymentDTOs\PaymentRequestDTO.cs
	namespace 	
PaymentService
 
. 
DTOs 
; 
public 
class 
PaymentRequestDto 
{ 
public 

double 

TotalPrice 
{ 
get "
;" #
set$ '
;' (
}) *
public 

double 
AgentRating 
{ 
get  #
;# $
set% (
;( )
}* +
public 

PaymentRequestDto 
( 
double #

totalPrice$ .
,. /
double0 6
agentRating7 B
)B C
{		 

TotalPrice

 
=

 

totalPrice

 
;

  
AgentRating 
= 
agentRating !
;! "
} 
public 

PaymentRequestDto 
( 
) 
{ 
} 
} ß
aC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\PaymentDTOs\PaymentDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
. 
PaymentDTOs  
;  !
public 
class 

PaymentDTO 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

double 

TotalPrice 
{ 
get "
;" #
set$ '
;' (
}) *
public		 

DateTime		 
Date		 
{		 
get		 
;		 
set		  #
;		# $
}		% &
public

 
!
PaymentProcessInfoDTO

  !
PaymentProcessInfoDTO

! 6
{

7 8
get

9 <
;

< =
set

> A
;

A B
}

C D
public 


PaymentDTO 
( 
) 
{ 
} 
public 


PaymentDTO 
( 
int 
id 
, 
double $

totalPrice% /
,/ 0
DateTime1 9
date: >
,> ?!
PaymentProcessInfoDTO@ U!
paymentProcessInfoDTOV k
)k l
{ 
Id 

= 
id 
; 

TotalPrice 
= 

totalPrice 
;  
Date 
= 
date 
; !
PaymentProcessInfoDTO 
= !
paymentProcessInfoDTO  5
;5 6
} 
} µ
lC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\PaymentDTOs\PaymentProcessInfoDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
. 
PaymentDTOs  
;  !
public 
class !
PaymentProcessInfoDTO "
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

double 
RestaurantEarnings $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 

double 

AgentBonus 
{ 
get "
;" #
set$ '
;' (
}) *
public 

double 
MTOGOFee 
{ 
get 
;  
set! $
;$ %
}& '
public

 
!
PaymentProcessInfoDTO

  
(

  !
)

! "
{ 
} 
public 
!
PaymentProcessInfoDTO  
(  !
int! $
id% '
,' (
double) /
restaurantEarnings0 B
,B C
doubleD J

agentBonusK U
,U V
doubleW ]
mtogoFee^ f
)f g
{ 
Id 

= 
id 
; 
RestaurantEarnings 
= 
restaurantEarnings /
;/ 0

AgentBonus 
= 

agentBonus 
;  
MTOGOFee 
= 
mtogoFee 
; 
} 
} ë
dC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\OrderDTOs\UpdateStatusDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
; 
public 
class 
UpdateStatusDTO 
{ 
public 

int 
OrderId 
{ 
get 
; 
set !
;! "
}# $
public 

string 
Status 
{ 
get 
; 
set  #
;# $
}% &
public 

UpdateStatusDTO 
( 
) 
{		 
}

 
public 

UpdateStatusDTO 
( 
int 
orderId &
,& '
string( .
status/ 5
)5 6
{ 
OrderId 
= 
orderId 
; 
Status 
= 
status 
; 
} 
} ∫

fC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\OrderDTOs\UpdateOrderIdsDTO.cs
	namespace 	#
OrderAndFeedbackService
 !
.! "
DTOs" &
;& '
public 
class 
UpdateOrderIdsDTO 
{ 
public 

int 
orderID 
{ 
get 
; 
set !
;! "
}# $
public 

int 
agentID 
{ 
get 
; 
set !
;! "
}# $
public 

int 
	paymentID 
{ 
get 
; 
set  #
;# $
}% &
public		 

UpdateOrderIdsDTO		 
(		 
int		  
orderID		! (
,		( )
int		* -
agentID		. 5
,		5 6
int		7 :
	paymentID		; D
)		D E
{

 
this 
. 
orderID 
= 
orderID 
; 
this 
. 
agentID 
= 
agentID 
; 
this 
. 
	paymentID 
= 
	paymentID "
;" #
} 
} ©
aC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\OrderDTOs\OrderLineDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
; 
public 
class 
OrderLineDTO 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

int 

MenuItemId 
{ 
get 
;  
set! $
;$ %
}& '
public 

int 
OrderId 
{ 
get 
; 
set !
;! "
}# $
public		 

int		 
Quantity		 
{		 
get		 
;		 
set		 "
;		" #
}		$ %
public 

OrderLineDTO 
( 
) 
{ 
} 
public 

OrderLineDTO 
( 
int 
id 
, 
int  #

menuItemId$ .
,. /
int/ 2
orderId3 :
,: ;
int< ?
quantity@ H
)H I
{ 
Id 

= 
id 
; 

MenuItemId 
= 

menuItemId 
;  
OrderId 
= 
orderId 
; 
Quantity 
= 
quantity 
; 
} 
} «%
]C:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\OrderDTOs\OrderDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
; 
public 
class 
OrderDTO 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

string 
? 
OrderNumber 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 

int 

CustomerId 
{ 
get 
;  
set! $
;$ %
}& '
public		 

int		 
AgentId		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
public

 

int

 
RestaurantId

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
public 

List 
< 
OrderLineDTO 
> 
OrderLinesDTOs ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 

int 
	PaymentId 
{ 
get 
; 
set  #
;# $
}% &
public 

int 

TotalPrice 
{ 
get 
;  
set! $
;$ %
}& '
public 

String 
Status 
{ 
get 
; 
set  #
;# $
}% &
public 

String 
Receipt 
{ 
get 
;  
set! $
;$ %
}& '
public 

OrderDTO 
( 
) 
{ 
} 
public 

OrderDTO 
( 
int 
id 
, 
string "
orderNumber# .
,. /
int0 3

customerId4 >
,> ?
int@ C
agentIdD K
,K L
intM P
restaurantIdQ ]
,] ^
List_ c
<c d
OrderLineDTOd p
>p q
orderLinesDtOs	r Ä
,
Ä Å
int
Ç Ö
	paymentId
Ü è
,
è ê
int
ë î

totalPrice
ï ü
,
ü †
string
° ß
status
® Æ
,
Æ Ø
string
∞ ∂
receipt
∑ æ
)
æ ø
{ 
Id 

= 
id 
; 
OrderNumber 
= 
orderNumber !
;! "

CustomerId 
= 

customerId 
;  
AgentId 
= 
agentId 
; 
RestaurantId 
= 
restaurantId #
;# $
OrderLinesDTOs 
= 
orderLinesDtOs '
;' (
	PaymentId 
= 
	paymentId 
; 

TotalPrice 
= 

totalPrice 
;  
Status   
=   
status   
;   
Receipt!! 
=!! 
receipt!! 
;!! 
}"" 
public$$ 

OrderDTO$$ 
($$ 
int$$ 
id$$ 
,$$ 
int$$ 

customerId$$  *
,$$* +
int$$, /
agentId$$0 7
,$$7 8
int$$9 <
restaurantId$$= I
,$$I J
List$$K O
<$$O P
OrderLineDTO$$P \
>$$\ ]
orderLinesDtOs$$^ l
,$$l m
int$$n q
	paymentId$$r {
,$${ |
int	$$} Ä

totalPrice
$$Å ã
,
$$ã å
string
$$ç ì
status
$$î ö
,
$$ö õ
string
$$ú ¢
receipt
$$£ ™
)
$$™ ´
{%% 
Id&& 

=&& 
id&& 
;&& 

CustomerId'' 
='' 

customerId'' 
;''  
AgentId(( 
=(( 
agentId(( 
;(( 
RestaurantId)) 
=)) 
restaurantId)) #
;))# $
OrderLinesDTOs** 
=** 
orderLinesDtOs** '
;**' (
	PaymentId++ 
=++ 
	paymentId++ 
;++ 

TotalPrice,, 
=,, 

totalPrice,, 
;,,  
Status-- 
=-- 
status-- 
;-- 
Receipt.. 
=.. 
receipt.. 
;.. 
}// 
}11 ﬁ

gC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\FeedbackDTOs\UpdateRatingDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
. 
FeedbackDTOs !
;! "
public 
class 
UpdateRatingDTO 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

double 
Rating 
{ 
get 
; 
set  #
;# $
}% &
public 

int 
NumberOfRatings 
{  
get! $
;$ %
set& )
;) *
}+ ,
public

 

UpdateRatingDTO

 
(

 
)

 
{ 
} 
public 

UpdateRatingDTO 
( 
int 
id !
,! "
double# )
rating* 0
,0 1
int2 5
numberOfRatings6 E
)E F
{ 
Id 

= 
id 
; 
Rating 
= 
rating 
; 
NumberOfRatings 
= 
numberOfRatings )
;) *
} 
} Ô
cC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\FeedbackDTOs\FeedbackDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
. 
FeedbackDTOs !
;! "
public 
class 
FeedbackDTO 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

OrderDTO 
OrderDTO 
{ 
get !
;! "
set# &
;& '
}( )
public 

String 
Title 
{ 
get 
; 
set "
;" #
}$ %
public 

String 
Description 
{ 
get  #
;# $
set% (
;( )
}* +
public		 

int		 
Agentrating		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public

 

int

 
RestaurantRating

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 

int 
OverAllRating 
{ 
get "
;" #
set$ '
;' (
}) *
public 

FeedbackDTO 
( 
) 
{ 
} 
public 

FeedbackDTO 
( 
int 
id 
, 
OrderDTO '
orderDto( 0
,0 1
string2 8
title9 >
,> ?
string@ F
descriptionG R
,R S
intT W
agentratingX c
,c d
inte h
restaurantRatingi y
,y z
int{ ~
overAllRating	 å
)
å ç
{ 
Id 

= 
id 
; 
OrderDTO 
= 
orderDto 
; 
Title 
= 
title 
; 
Description 
= 
description !
;! "
Agentrating 
= 
agentrating !
;! "
RestaurantRating 
= 
restaurantRating +
;+ ,
OverAllRating 
= 
overAllRating %
;% &
} 
public 

FeedbackDTO 
( 
int 
id 
, 
string %
title& +
,+ ,
string- 3
description4 ?
,? @
intA D
agentratingE P
,P Q
intR U
restaurantRatingV f
,f g
inth k
overAllRatingl y
)y z
{ 
Id 

= 
id 
; 
Title 
= 
title 
; 
Description   
=   
description   !
;  ! "
Agentrating!! 
=!! 
agentrating!! !
;!!! "
RestaurantRating"" 
="" 
restaurantRating"" +
;""+ ,
OverAllRating## 
=## 
overAllRating## %
;##% &
}$$ 
}%% ã
cC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\CustomerDTOs\CustomerDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
. 
CustomerDTOs !
;! "
public 
class 
CustomerDTO 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

string 
Email 
{ 
get 
; 
set "
;" #
}$ %
public		 

PaymentInfoDTO		 
PaymentInfoDTO		 (
{		) *
get		+ .
;		. /
set		0 3
;		3 4
}		5 6
public

 


AddressDTO

 

AddressDTO

  
{

! "
get

# &
;

& '
set

( +
;

+ ,
}

- .
public 

CustomerDTO 
( 
int 
id 
, 
string %
email& +
,+ ,
PaymentInfoDTO- ;
paymentInfoDto< J
,J K

AddressDTOL V

addressDtoW a
)a b
{ 
Id 

= 
id 
; 
Email 
= 
email 
; 
PaymentInfoDTO 
= 
paymentInfoDto '
;' (

AddressDTO 
= 

addressDto 
;  
} 
public 

CustomerDTO 
( 
) 
{ 
} 
} Ï

fC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\CustomerDTOs\PaymentInfoDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
. 
CustomerDTOs !
;! "
public 
class 
PaymentInfoDTO 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

String 

CardNumber 
{ 
get "
;" #
set$ '
;' (
}) *
public 

String 
ExpirationDate  
{! "
get# &
;& '
set( +
;+ ,
}- .
public

 

PaymentInfoDTO

 
(

 
int

 
id

  
,

  !
string

" (

cardNumber

) 3
,

3 4
string

5 ;
expirationDate

< J
)

J K
{ 
Id 

= 
id 
; 

CardNumber 
= 

cardNumber 
;  
ExpirationDate 
= 
expirationDate '
;' (
} 
public 

PaymentInfoDTO 
( 
) 
{ 
} 
} ò
iC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\AgentDTOs\UpdateStatusAgentDTO.cs
	namespace 	
AgentService
 
. 
DTOs 
; 
public 
class  
UpdateStatusAgentDTO !
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

String 
Status 
{ 
get 
; 
set  #
;# $
}% &
public		 
 
UpdateStatusAgentDTO		 
(		  
)		  !
{

 
} 
public 
 
UpdateStatusAgentDTO 
(  
int  #
id$ &
,& '
string( .
status/ 5
)5 6
{ 
Id 

= 
id 
; 
Status 
= 
status 
; 
} 
} Ï

iC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\AgentDTOs\UpdateRatingAgentDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
. 
	AgentDTOs 
; 
public 
class  
UpdateRatingAgentDTO !
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

double 
Rating 
{ 
get 
; 
set  #
;# $
}% &
public 

int 
NumberOfRatings 
{  
get! $
;$ %
set& )
;) *
}+ ,
public

 
 
UpdateRatingAgentDTO

 
(

  
)

  !
{ 
} 
public 
 
UpdateRatingAgentDTO 
(  
int  #
id$ &
,& '
double( .
rating/ 5
,5 6
int7 :
numberOfRatings; J
)J K
{ 
Id 

= 
id 
; 
Rating 
= 
rating 
; 
NumberOfRatings 
= 
numberOfRatings )
;) *
} 
} ˜
]C:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\DTOs\AgentDTOs\AgentDTO.cs
	namespace 	
MTOGO
 
. 
DTOs 
. 
	AgentDTOs 
; 
public 
class 
AgentDTO 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

String 
Name 
{ 
get 
; 
set !
;! "
}# $
public 

int 
PhoneNumber 
{ 
get  
;  !
set" %
;% &
}' (
public 

String 
AccountNumber 
{  !
get" %
;% &
set' *
;* +
}, -
public		 

String		 
AgentId		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
public

 

String

 
Status

 
{

 
get

 
;

 
set

  #
;

# $
}

% &
public 

String 
Region 
{ 
get 
; 
set  #
;# $
}% &
public 

double 
Rating 
{ 
get 
; 
set  #
;# $
}% &
public 

int 
NumberOfRatings 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 

AgentDTO 
( 
) 
{ 
} 
public 

AgentDTO 
( 
int 
id 
, 
string "
name# '
,' (
int) ,
phoneNumber- 8
,8 9
string: @
accountNumberA N
,N O
stringP V
agentIdW ^
,^ _
string` f
statusg m
,m n
stringo u
regionv |
,| }
double	~ Ñ
rating
Ö ã
,
ã å
int
ç ê
numberOfRatings
ë †
)
† °
{ 
Id 

= 
id 
; 
Name 
= 
name 
; 
PhoneNumber 
= 
phoneNumber !
;! "
AccountNumber 
= 
accountNumber %
;% &
AgentId 
= 
agentId 
; 
Status 
= 
status 
; 
Region 
= 
region 
; 
Rating 
= 
rating 
; 
NumberOfRatings 
= 
numberOfRatings )
;) *
} 
}!! ˆ

`C:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Configurations\ApiSettings.cs
	namespace 	
MTOGO
 
. 
Configurations 
{ 
public 

class 
ApiSettings 
{ 
public 
string 
ResUrl 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
OrderUrl 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
FeedbackUrl !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
UserUrl 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
string		 

PaymentUrl		  
{		! "
get		# &
;		& '
set		( +
;		+ ,
}		- .
public

 
string

 
AgentUrl

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
public 
string 
CustomerUrl !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} Œ
QC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Api\UserApi.cs
	namespace 	
MTOGO
 
. 
Api 
; 
[		 
ApiController		 
]		 
[

 
Route

 
(

 
$str

 
)

 
]

 
public 
class 
UserApi 
: 
ControllerBase %
{ 
private 
readonly 
IFacadeFactory #
_facadeFactory$ 2
;2 3
public 

UserApi 
( 
IFacadeFactory !
facadeFactory" /
)/ 0
{ 
_facadeFactory 
= 
facadeFactory &
;& '
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $

CreateUser% /
(/ 0
[0 1
FromBody1 9
]9 :
UserDTO; B
userDtoC J
)J K
{ 
try 
{ 	
IUserInterface 

userFacade %
=& '
_facadeFactory( 6
.6 7
GetUserFacade7 D
(D E
)E F
;F G
UserDTO 
createdUser 
=  !
await" '

userFacade( 2
.2 3
CreateUserAsync3 B
(B C
userDtoC J
)J K
;K L
return 
Ok 
( 
createdUser !
)! "
;" #
} 	
catch 
( 
	Exception 
ex 
) 
{ 	
return   

BadRequest   
(   
ex    
.    !
Message  ! (
)  ( )
;  ) *
}!! 	
}"" 
[%% 
HttpPost%% 
(%% 
$str%% 
)%% 
]%% 
public&& 

async&& 
Task&& 
<&& 
IActionResult&& #
>&&# $
Login&&% *
(&&* +
[&&+ ,
FromBody&&, 4
]&&4 5
UserDTO&&6 =
userDto&&> E
)&&E F
{'' 
try(( 
{)) 	
IUserInterface** 

userFacade** %
=**& '
_facadeFactory**( 6
.**6 7
GetUserFacade**7 D
(**D E
)**E F
;**F G
UserDTO++ 
loggedInUser++  
=++! "
await++# (

userFacade++) 3
.++3 4
LoginUserAsync++4 B
(++B C
userDto++C J
)++J K
;++K L
return,, 
Ok,, 
(,, 
loggedInUser,, "
),," #
;,,# $
}-- 	
catch.. 
(.. 
	Exception.. 
ex.. 
).. 
{// 	
return00 

BadRequest00 
(00 
ex00  
.00  !
Message00! (
)00( )
;00) *
}11 	
}22 
}33 ÑE
WC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Api\RestaurantApi.cs
	namespace 	
MTOGO
 
. 
Api 
; 
[ 
ApiController 
] 
[		 
Route		 
(		 
$str		 
)		 
]		 
public 
class 
RestaurantApi 
: 
ControllerBase +
{ 
private 
readonly 
IFacadeFactory #
_facadeFactory$ 2
;2 3
public 

RestaurantApi 
( 
IFacadeFactory '
factory( /
)/ 0
{ 
_facadeFactory 
= 
factory  
;  !
} 
[ 
HttpGet 
] 
public 

async 
Task 
< 
IActionResult #
># $
GetRestaurants% 3
(3 4
)4 5
{  
IRestaurantInterface 
restaurantFacade -
=. /
_facadeFactory0 >
.> ?
GetResFacade? K
(K L
)L M
;M N
List 
< 
RestaurantDTO 
> 
dtos  
=! "
await# (
restaurantFacade) 9
.9 :
GetRestaurants: H
(H I
)I J
;J K
return 
Ok 
( 
dtos 
) 
; 
} 
[   
HttpGet   
(   
$str   
)   
]   
public!! 

async!! 
Task!! 
<!! 
IActionResult!! #
>!!# $
GetRestaurant!!% 2
(!!2 3
int!!3 6
id!!7 9
)!!9 :
{"" 
try## 
{$$ 	 
IRestaurantInterface%%  
restaurantFacade%%! 1
=%%2 3
_facadeFactory%%4 B
.%%B C
GetResFacade%%C O
(%%O P
)%%P Q
;%%Q R
RestaurantDTO&& 
dto&& 
=&& 
await&&  %
restaurantFacade&&& 6
.&&6 7
GetRestaurant&&7 D
(&&D E
id&&E G
)&&G H
;&&H I
return'' 
Ok'' 
('' 
dto'' 
)'' 
;'' 
}(( 	
catch)) 
()) 
	Exception)) 
ex)) 
))) 
{** 	
return++ 

BadRequest++ 
(++ 
ex++  
.++  !
Message++! (
)++( )
;++) *
},, 	
}-- 
[00 
HttpPost00 
]00 
public11 

async11 
Task11 
<11 
IActionResult11 #
>11# $
CreateRestaurant11% 5
(115 6
[116 7
FromBody117 ?
]11? @
RestaurantDTO11A N
restaurantDto11O \
)11\ ]
{22 
try33 
{44 	 
IRestaurantInterface55  
restaurantFacade55! 1
=552 3
_facadeFactory554 B
.55B C
GetResFacade55C O
(55O P
)55P Q
;55Q R
RestaurantDTO66 
createdRestaurant66 +
=66, -
await66. 3
restaurantFacade664 D
.66D E
CreateRestaurant66E U
(66U V
restaurantDto66V c
)66c d
;66d e
return77 
Ok77 
(77 
createdRestaurant77 '
)77' (
;77( )
}88 	
catch99 
(99 
	Exception99 
ex99 
)99 
{:: 	
return;; 

BadRequest;; 
(;; 
ex;;  
.;;  !
Message;;! (
);;( )
;;;) *
}<< 	
}== 
[@@ 
HttpPut@@ 
]@@ 
publicAA 

asyncAA 
TaskAA 
<AA 
IActionResultAA #
>AA# $
UpdateRestaurantAA% 5
(AA5 6
[AA6 7
FromBodyAA7 ?
]AA? @
RestaurantDTOAAA N
restaurantDtoAAO \
)AA\ ]
{BB 
tryCC 
{DD 	 
IRestaurantInterfaceEE  
restaurantFacadeEE! 1
=EE2 3
_facadeFactoryEE4 B
.EEB C
GetResFacadeEEC O
(EEO P
)EEP Q
;EEQ R
RestaurantDTOFF 
updatedRestaurantFF +
=FF, -
awaitFF. 3
restaurantFacadeFF4 D
.FFD E
UpdateRestaurantFFE U
(FFU V
restaurantDtoFFV c
)FFc d
;FFd e
returnGG 
OkGG 
(GG 
updatedRestaurantGG '
)GG' (
;GG( )
}HH 	
catchII 
(II 
	ExceptionII 
exII 
)II 
{JJ 	
returnKK 

BadRequestKK 
(KK 
exKK  
.KK  !
MessageKK! (
)KK( )
;KK) *
}LL 	
}MM 
[PP 
HttpPostPP 
(PP 
$strPP 
)PP 
]PP 
publicQQ 

asyncQQ 
TaskQQ 
<QQ 
IActionResultQQ #
>QQ# $
CreateMenuItemQQ% 3
(QQ3 4
[QQ4 5
FromBodyQQ5 =
]QQ= >
MenuItemDTOQQ? J
menuItemDtoQQK V
)QQV W
{RR 
trySS 
{TT 	 
IRestaurantInterfaceUU  
restaurantFacadeUU! 1
=UU2 3
_facadeFactoryUU4 B
.UUB C
GetResFacadeUUC O
(UUO P
)UUP Q
;UUQ R
MenuItemDTOVV 
createdMenuItemVV '
=VV( )
awaitVV* /
restaurantFacadeVV0 @
.VV@ A
CreateMenuItemVVA O
(VVO P
menuItemDtoVVP [
)VV[ \
;VV\ ]
returnWW 
OkWW 
(WW 
createdMenuItemWW %
)WW% &
;WW& '
}XX 	
catchYY 
(YY 
	ExceptionYY 
exYY 
)YY 
{ZZ 	
return[[ 

BadRequest[[ 
([[ 
ex[[  
.[[  !
Message[[! (
)[[( )
;[[) *
}\\ 	
}]] 
[`` 
HttpPut`` 
(`` 
$str`` 
)`` 
]`` 
publicaa 

asyncaa 
Taskaa 
<aa 
IActionResultaa #
>aa# $
UpdateMenuItemaa% 3
(aa3 4
[aa4 5
FromBodyaa5 =
]aa= >
MenuItemDTOaa? J
menuItemDtoaaK V
)aaV W
{bb 
trycc 
{dd 	 
IRestaurantInterfaceee  
restaurantFacadeee! 1
=ee2 3
_facadeFactoryee4 B
.eeB C
GetResFacadeeeC O
(eeO P
)eeP Q
;eeQ R
MenuItemDTOff 
updatedMenuItemff '
=ff( )
awaitff* /
restaurantFacadeff0 @
.ff@ A
UpdateMenuItemffA O
(ffO P
menuItemDtoffP [
)ff[ \
;ff\ ]
returngg 
Okgg 
(gg 
updatedMenuItemgg %
)gg% &
;gg& '
}hh 	
catchii 
(ii 
	Exceptionii 
exii 
)ii 
{jj 	
returnkk 

BadRequestkk 
(kk 
exkk  
.kk  !
Messagekk! (
)kk( )
;kk) *
}ll 	
}mm 
[pp 
HttpGetpp 
(pp 
$strpp 
)pp 
]pp 
publicqq 

asyncqq 
Taskqq 
<qq 
IActionResultqq #
>qq# $
GetMenuItemsqq% 1
(qq1 2
intqq2 5
idqq6 8
)qq8 9
{rr 
tryss 
{tt 	 
IRestaurantInterfaceuu  
restaurantFacadeuu! 1
=uu2 3
_facadeFactoryuu4 B
.uuB C
GetResFacadeuuC O
(uuO P
)uuP Q
;uuQ R
Listvv 
<vv 
MenuItemDTOvv 
>vv 
dtosvv "
=vv# $
awaitvv% *
restaurantFacadevv+ ;
.vv; <
GetMenuItemsvv< H
(vvH I
idvvI K
)vvK L
;vvL M
returnww 
Okww 
(ww 
dtosww 
)ww 
;ww 
}xx 	
catchyy 
(yy 
	Exceptionyy 
exyy 
)yy 
{zz 	
return{{ 

BadRequest{{ 
({{ 
ex{{  
.{{  !
Message{{! (
){{( )
;{{) *
}|| 	
}}} 
} «B
RC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Api\OrderApi.cs
	namespace 	
MTOGO
 
. 
Api 
; 
[		 
ApiController		 
]		 
[

 
Route

 
(

 
$str

 
)

 
]

 
public 
class 
OrderApi 
: 
ControllerBase &
{ 
private 
readonly 
IFacadeFactory #
_facadeFactory$ 2
;2 3
public 

OrderApi 
( 
IFacadeFactory "
factory# *
)* +
{ 
_facadeFactory 
= 
factory  
;  !
} 
[ 
HttpGet 
] 
public 

async 
Task 
< 
IActionResult #
># $
	GetOrders% .
(. /
)/ 0
{ 
IOrderInterface 
orderFacade #
=$ %
_facadeFactory& 4
.4 5
GetOrderFacade5 C
(C D
)D E
;E F
string 
json 
= 
await 
orderFacade '
.' (
GetAllOrders( 4
(4 5
)5 6
;6 7
return 
Ok 
( 
json 
) 
; 
} 
[   
HttpGet   
(   
$str   
)   
]   
public!! 

async!! 
Task!! 
<!! 
IActionResult!! #
>!!# $
GetOrder!!% -
(!!- .
int!!. 1
id!!2 4
)!!4 5
{"" 
IOrderInterface## 
orderFacade## #
=##$ %
_facadeFactory##& 4
.##4 5
GetOrderFacade##5 C
(##C D
)##D E
;##E F
string$$ 
json$$ 
=$$ 
await$$ 
orderFacade$$ '
.$$' (
GetOrder$$( 0
($$0 1
id$$1 3
)$$3 4
;$$4 5
return%% 
Ok%% 
(%% 
json%% 
)%% 
;%% 
}&& 
[(( 
HttpPost(( 
](( 
public)) 

async)) 
Task)) 
<)) 
IActionResult)) #
>))# $
CreateMenuItem))% 3
())3 4
[))4 5
FromBody))5 =
]))= >
OrderDTO))? G
orderDto))H P
)))P Q
{** 
try++ 
{,, 	
IOrderInterface-- 
orderFacade-- '
=--( )
_facadeFactory--* 8
.--8 9
GetOrderFacade--9 G
(--G H
)--H I
;--I J
OrderDTO.. 
createdOrderDto.. $
=..% &
await..' ,
orderFacade..- 8
...8 9
CreateOrder..9 D
(..D E
orderDto..E M
)..M N
;..N O
return// 
Ok// 
(// 
createdOrderDto// %
)//% &
;//& '
}00 	
catch11 
(11 
	Exception11 
ex11 
)11 
{22 	
return33 

BadRequest33 
(33 
ex33  
.33  !
Message33! (
)33( )
;33) *
}44 	
}55 
[77 
HttpPut77 
]77 
public88 

async88 
Task88 
<88 
IActionResult88 #
>88# $
UpdateOrderStatus88% 6
(886 7
[887 8
FromBody888 @
]88@ A
UpdateStatusDTO88B Q
orderDto88R Z
)88Z [
{99 
try:: 
{;; 	
IOrderInterface<< 
orderFacade<< '
=<<( )
_facadeFactory<<* 8
.<<8 9
GetOrderFacade<<9 G
(<<G H
)<<H I
;<<I J
OrderDTO== 
updatedOrderDto== $
===% &
await==' ,
orderFacade==- 8
.==8 9
UpdateOrderStatus==9 J
(==J K
orderDto==K S
)==S T
;==T U
return>> 
Ok>> 
(>> 
updatedOrderDto>> %
)>>% &
;>>& '
}?? 	
catch@@ 
(@@ 
	Exception@@ 
ex@@ 
)@@ 
{AA 	
returnBB 

BadRequestBB 
(BB 
exBB  
.BB  !
MessageBB! (
)BB( )
;BB) *
}CC 	
}DD 
[FF 
HttpGetFF 
(FF 
$strFF 
)FF 
]FF  
publicGG 

asyncGG 
TaskGG 
<GG 
IActionResultGG #
>GG# $
GetOrderByStatusGG% 5
(GG5 6
stringGG6 <
statusGG= C
)GGC D
{HH 
IOrderInterfaceII 
orderFacadeII #
=II$ %
_facadeFactoryII& 4
.II4 5
GetOrderFacadeII5 C
(IIC D
)IID E
;IIE F
ListJJ 
<JJ 
OrderDTOJJ 
>JJ 
jsonJJ 
=JJ 
awaitJJ #
orderFacadeJJ$ /
.JJ/ 0
GetOrdersByStatusJJ0 A
(JJA B
statusJJB H
)JJH I
;JJI J
returnKK 
OkKK 
(KK 
jsonKK 
)KK 
;KK 
}LL 
[NN 
HttpPutNN 
(NN 
$strNN 
)NN 
]NN 
publicOO 

asyncOO 
TaskOO 
<OO 
IActionResultOO #
>OO# $
UpdateOrderIdsOO% 3
(OO3 4
[OO4 5
FromBodyOO5 =
]OO= >
UpdateOrderIdsDTOOO? P
DtoOOQ T
)OOT U
{PP 
tryQQ 
{RR 	
IOrderInterfaceSS 
orderFacadeSS '
=SS( )
_facadeFactorySS* 8
.SS8 9
GetOrderFacadeSS9 G
(SSG H
)SSH I
;SSI J
OrderDTOTT 
updatedOrderDtoTT $
=TT% &
awaitTT' ,
orderFacadeTT- 8
.TT8 9
UpdateOrderTT9 D
(TTD E
DtoTTE H
)TTH I
;TTI J
returnUU 
OkUU 
(UU 
updatedOrderDtoUU %
)UU% &
;UU& '
}VV 	
catchWW 
(WW 
	ExceptionWW 
exWW 
)WW 
{XX 	
returnYY 

BadRequestYY 
(YY 
exYY  
.YY  !
MessageYY! (
)YY( )
;YY) *
}ZZ 	
}[[ 
[]] 
HttpGet]] 
(]] 
$str]] 
)]] 
]]] 
public^^ 

async^^ 
Task^^ 
<^^ 
IActionResult^^ #
>^^# $
GetOrderByAgent^^% 4
(^^4 5
int^^5 8
id^^9 ;
)^^; <
{__ 
IOrderInterface`` 
orderFacade`` #
=``$ %
_facadeFactory``& 4
.``4 5
GetOrderFacade``5 C
(``C D
)``D E
;``E F
Listaa 
<aa 
OrderDTOaa 
>aa 
jsonaa 
=aa 
awaitaa #
orderFacadeaa$ /
.aa/ 0
GetOrdersByAgentIdaa0 B
(aaB C
idaaC E
)aaE F
;aaF G
returnbb 
Okbb 
(bb 
jsonbb 
)bb 
;bb 
}cc 
[ee 
HttpGetee 
(ee 
$stree 
)ee 
]ee 
publicff 

asyncff 
Taskff 
<ff 
IActionResultff #
>ff# $
GetOrderByCustomerff% 7
(ff7 8
intff8 ;
idff< >
)ff> ?
{gg 
IOrderInterfacehh 
orderFacadehh #
=hh$ %
_facadeFactoryhh& 4
.hh4 5
GetOrderFacadehh5 C
(hhC D
)hhD E
;hhE F
Listii 
<ii 
OrderDTOii 
>ii 
jsonii 
=ii 
awaitii #
orderFacadeii$ /
.ii/ 0!
GetOrdersByCustomerIDii0 E
(iiE F
idiiF H
)iiH I
;iiI J
returnjj 
Okjj 
(jj 
jsonjj 
)jj 
;jj 
}kk 
}ll Ì
TC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Api\PaymentApi.cs
	namespace 	
MTOGO
 
. 
Api 
; 
[		 
ApiController		 
]		 
[

 
Route

 
(

 
$str

 
)

 
]

 
public 
class 

PaymentApi 
: 
ControllerBase (
{ 
private 
readonly 
IFacadeFactory #
_facadeFactory$ 2
;2 3
public 


PaymentApi 
( 
IFacadeFactory $
factory% ,
), -
{ 
_facadeFactory 
= 
factory  
;  !
} 
[ 
HttpGet 
( 
$str 
) 
] 
public 

async 
Task 
< 
IActionResult #
># $

GetPayment% /
(/ 0
int0 3
id4 6
)6 7
{ 
IPaymentInterface 
paymentFacade '
=( )
_facadeFactory* 8
.8 9
GetPaymentFacade9 I
(I J
)J K
;K L
var 
payments 
= 
await 
paymentFacade *
.* +
GetPaymentById+ 9
(9 :
id: <
)< =
;= >
return 
Ok 
( 
payments 
) 
; 
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
CreatePayment% 2
(2 3
[3 4
FromBody4 <
]< =
PaymentRequestDto> O
requestP W
)W X
{   
try!! 
{"" 	
IPaymentInterface## 
paymentFacade## +
=##, -
_facadeFactory##. <
.##< =
GetPaymentFacade##= M
(##M N
)##N O
;##O P

PaymentDTO$$ 
payment$$ 
=$$  
await$$! &
paymentFacade$$' 4
.$$4 5
CreatePayment$$5 B
($$B C
request$$C J
)$$J K
;$$K L
return%% 
Ok%% 
(%% 
payment%% 
)%% 
;%% 
}&& 	
catch'' 
('' 
	Exception'' 
ex'' 
)'' 
{(( 	
return)) 

BadRequest)) 
()) 
ex))  
.))  !
Message))! (
)))( )
;))) *
}** 	
}++ 
},, Õ
UC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Api\FeedbackApi.cs
	namespace 	
MTOGO
 
. 
Api 
; 
[		 
ApiController		 
]		 
[

 
Route

 
(

 
$str

 
)

 
]

 
public 
class 
FeedbackApi 
: 
ControllerBase )
{ 
private 
readonly 
IFacadeFactory #
_facadeFactory$ 2
;2 3
public 

FeedbackApi 
( 
IFacadeFactory %
factory& -
)- .
{ 
_facadeFactory 
= 
factory  
;  !
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
CreateFeedback% 3
(3 4
[4 5
FromBody5 =
]= >
FeedbackDTO? J
feedbackDtoK V
)V W
{ 
try 
{ 	
IFeedbackInterface 
feedbackFacade -
=. /
_facadeFactory0 >
.> ?
GetFeedbackFacade? P
(P Q
)Q R
;R S
FeedbackDTO 
createdFeedback '
=( )
await* /
feedbackFacade0 >
.> ?
CreateFeedback? M
(M N
feedbackDtoN Y
)Y Z
;Z [
return 
Ok 
( 
createdFeedback %
)% &
;& '
} 	
catch   
(   
	Exception   
ex   
)   
{!! 	
return"" 

BadRequest"" 
("" 
ex""  
.""  !
Message""! (
)""( )
;"") *
}## 	
}$$ 
}'' —
UC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Api\CustomerApi.cs
	namespace 	
MTOGO
 
. 
Api 
; 
[		 
ApiController		 
]		 
[

 
Route

 
(

 
$str

 
)

 
]

 
public 
class 
CustomerApi 
: 
ControllerBase )
{ 
private 
readonly 
IFacadeFactory #
_facadeFactory$ 2
;2 3
public 

CustomerApi 
( 
IFacadeFactory %
factory& -
)- .
{ 
_facadeFactory 
= 
factory  
;  !
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
CreateCustomer% 3
(3 4
[4 5
FromBody5 =
]= >
CustomerDTO? J
customerDtoK V
)V W
{ 
ICustomerInterface 
customerFacade )
=* +
_facadeFactory, :
.: ;
GetCustomerFacade; L
(L M
)M N
;N O
var 
createdCustomer 
= 
await #
customerFacade$ 2
.2 3
CreateCustomer3 A
(A B
customerDtoB M
)M N
;N O
return 
Ok 
( 
createdCustomer !
)! "
;" #
} 
[ 
HttpGet 
( 
$str 
) 
] 
public 

async 
Task 
< 
IActionResult #
># $
GetCustomer% 0
(0 1
int1 4
id5 7
)7 8
{ 
ICustomerInterface   
customerFacade   )
=  * +
_facadeFactory  , :
.  : ;
GetCustomerFacade  ; L
(  L M
)  M N
;  N O
var!! 
customer!! 
=!! 
await!! 
customerFacade!! +
.!!+ ,
GetCustomer!!, 7
(!!7 8
id!!8 :
)!!: ;
;!!; <
return"" 
Ok"" 
("" 
customer"" 
)"" 
;"" 
}## 
}$$ Å
RC:\Users\mrott\Documents\GitHub\SOFTExam_MTOGO_Backend\MTOGO\MTOGO\Api\AgentApi.cs
	namespace 	
MTOGO
 
. 
Api 
; 
[		 
ApiController		 
]		 
[

 
Route

 
(

 
$str

 
)

 
]

 
public 
class 
AgentApi 
: 
ControllerBase &
{ 
private 
readonly 
IFacadeFactory #
_facadeFactory$ 2
;2 3
public 

AgentApi 
( 
IFacadeFactory "
factory# *
)* +
{ 
_facadeFactory 
= 
factory  
;  !
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
CreateAgent% 0
(0 1
[1 2
FromBody2 :
]: ;
AgentDTO< D
agentDtoE M
)M N
{ 
IAgentInterface 
agentFacade #
=$ %
_facadeFactory& 4
.4 5
GetAgentFacade5 C
(C D
)D E
;E F
var 
agent 
= 
await 
agentFacade %
.% &
CreateAgent& 1
(1 2
agentDto2 :
): ;
;; <
return 
Ok 
( 
agent 
) 
; 
} 
[ 
HttpGet 
( 
$str 
) 
] 
public 

async 
Task 
< 
IActionResult #
># $
GetAgent% -
(- .
int. 1
id2 4
)4 5
{ 
IAgentInterface   
agentFacade   #
=  $ %
_facadeFactory  & 4
.  4 5
GetAgentFacade  5 C
(  C D
)  D E
;  E F
var!! 
agent!! 
=!! 
await!! 
agentFacade!! %
.!!% &
GetAgent!!& .
(!!. /
id!!/ 1
)!!1 2
;!!2 3
return"" 
Ok"" 
("" 
agent"" 
)"" 
;"" 
}## 
}$$ 