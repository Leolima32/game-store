Ø
dC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\AutoMapper\AutoMapperConfig.cs
	namespace 	
	GameStore
 
. 
Application 
.  

AutoMapper  *
{ 
public 

class 
AutoMapperConfig !
{ 
public 
static 
MapperConfiguration )
RegisterMappings* :
(: ;
); <
{= >
return 
new 
MapperConfiguration *
(* +
c, -
=>. 0
{1 2
c		 
.		 

AddProfile		 
(		 
new		  +
DomainToViewModelMappingProfile		! @
(		@ A
)		A B
)		B C
;		C D
c

 
.

 

AddProfile

 
(

 
new

  +
ViewModelToDomainMappingProfile

! @
(

@ A
)

A B
)

B C
;

C D
} 
) 
; 
} 	
} 
} Ÿ
sC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\AutoMapper\DomainToViewModelMappingProfile.cs
	namespace 	
	GameStore
 
. 
Application 
.  

AutoMapper  *
{ 
public 

class +
DomainToViewModelMappingProfile 0
:0 1
Profile2 9
{ 
public		 +
DomainToViewModelMappingProfile		 .
(		. /
)		/ 0
{

 	
ShouldMapField 
= 
	fieldInfo &
=>' )
true* .
;. /
ShouldMapProperty 
= 
propertyInfo  ,
=>- /
true0 4
;4 5
	CreateMap 
< 
Game 
, 
GameViewModel (
>( )
() *
)* +
;+ ,
	CreateMap 
< 
Game 
, 
GameListViewModel ,
>, -
(- .
). /
;/ 0
	CreateMap 
< 
Company 
, 
CompanyViewModel .
>. /
(/ 0
)0 1
;1 2
	CreateMap 
< 
Genre 
, 
GenreViewModel *
>* +
(+ ,
), -
;- .
	CreateMap 
< 
Platform 
, 
PlatformViewModel  1
>1 2
(2 3
)3 4
;4 5
	CreateMap 
< 
Review 
, 
ReviewListViewModel 1
>1 2
(2 3
)3 4
;4 5
} 	
} 
} •
sC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\AutoMapper\ViewModelToDomainMappingProfile.cs
	namespace		 	
	GameStore		
 
.		 
Application		 
.		  

AutoMapper		  *
{

 
public 

class +
ViewModelToDomainMappingProfile 0
:0 1
Profile2 9
{ 
public +
ViewModelToDomainMappingProfile .
(. /
)/ 0
{ 	
ShouldMapField 
= 
	fieldInfo &
=>' )
true* .
;. /
ShouldMapProperty 
= 
propertyInfo  ,
=>- /
true0 4
;4 5
	CreateMap 
< 
AddOrUpdateGameDTO (
,( )
Game) -
>- .
(. /
)/ 0
;0 1
	CreateMap 
< !
AddOrUpdateCompanyDTO +
,+ ,
Company- 4
>4 5
(5 6
)6 7
;7 8
	CreateMap 
< 
AddOrUpdateGenreDTO )
,) *
Genre+ 0
>0 1
(1 2
)2 3
;3 4
	CreateMap 
< "
AddOrUpdatePlatformDTO ,
,, -
Platform. 6
>6 7
(7 8
)8 9
;9 :
} 	
} 
} Õ
_C:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Commands\CommandResult.cs
	namespace 	
	GameStore
 
. 
Application 
.  
Commands  (
{ 
public 

class 
CommandResult 
{ 
public		 
CommandResult		 
(		 
)		 
{

 	
} 	
public 
CommandResult 
( 
bool !
success" )
,) *
string+ 1
message2 9
)9 :
{ 	
Success 
= 
success 
; 
Message 
= 
message 
; 
} 	
public 
bool 
Success 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} ï
nC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Commands\FinishCreditCardOrderCommand.cs
	namespace 	
	GameStore
 
. 
Application 
.  
Commands  (
{ 
public 

class (
FinishCreditCardOrderCommand -
{		 
public

 
IList

 
<

 
CartItem

 
>

 
ListOfItems

 *
{

+ ,
get

- 0
;

0 1
set

2 5
;

5 6
}

7 8
=

9 :
new

; >
List

? C
<

C D
CartItem

D L
>

L M
(

M N
)

N O
;

O P
public 
string 
	FirstName 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Document 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
CardHolderName $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
string 

CardNumber  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string !
LastTransactionNumber +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string 
PaymentNumber #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
DateTime 
PaidDate  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
DateTime 

ExpireDate "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
decimal 
Total 
{ 
get "
;" #
set$ '
;' (
}) *
public 
decimal 
	TotalPaid  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
Payer 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
PayerDocument #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 

PayerEmail  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
void 
Validate 
( 
) 
{  
}! "
}   
}!! È
jC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Commands\FinishPayPalOrderCommand.cs
	namespace 	
	GameStore
 
. 
Application 
.  
Commands  (
{ 
public 

class $
FinishPayPalOrderCommand )
{		 
public

 
IList

 
<

 
CartItem

 
>

 
ListOfItems

 *
=

+ ,
new

- 0
List

1 5
<

5 6
CartItem

6 >
>

> ?
(

? @
)

@ A
;

A B
public 
string 
	FirstName 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Document 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
TransactionCode %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
PaymentNumber #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
DateTime 
PaidDate  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
DateTime 

ExpireDate "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
decimal 
Total 
{ 
get "
;" #
set$ '
;' (
}) *
public 
decimal 
	TotalPaid  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
Payer 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
PayerDocument #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 

PayerEmail  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
void 
Validate 
( 
) 
{  
}! "
} 
} Ú
nC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\DTOS\Comapanies\AddOrUpdateCompanyDTO.cs
	namespace 	
	GameStore
 
. 
Application 
.  
DTOS  $
.$ %
	Companies% .
{ 
public 

class !
AddOrUpdateCompanyDTO &
{' (
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
DateTime 
Founded 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
string		 
LogoPath		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
}

 
} œ
fC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\DTOS\Games\AddOrUpdateGameDTO.cs
	namespace 	
	GameStore
 
. 
Application 
.  
DTOS  $
.$ %
Games% *
{ 
public 

class 
AddOrUpdateGameDTO #
{		 
public

 
Guid

 
Id

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
[ 	
Required	 
( 
) 
] 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
DateTime 
ReleaseDate #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
Required	 
( 
) 
] 
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
ShortDescription &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 7
)7 8
]8 9
public 
ICollection 
< 
GameDeveloper (
>( )
GameDevelopers* 8
{9 :
get; >
;> ?
set@ C
;C D
}E F
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 6
)6 7
]7 8
public 
ICollection 
< 
GamePlatform '
>' (
GamePlatforms) 6
{7 8
get9 <
;< =
set> A
;A B
}C D
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 3
)3 4
]4 5
public 
ICollection 
< 
	GameGenre $
>$ %

GameGenres& 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public 
ICollection 
< 
GamePublisher (
>( )
GamePublishers* 8
{9 :
get; >
;> ?
set@ C
;C D
}E F
} 
} Õ
hC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\DTOS\Genres\AddOrUpdateGenreDTO.cs
	namespace 	
	GameStore
 
. 
Application 
.  
DTOS  $
.$ %
Genres% +
{ 
public 

class 
AddOrUpdateGenreDTO $
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public		 
string		 
Description		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
}

 
} ∫
nC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\DTOS\Platforms\AddOrUpdatePlatformDTO.cs
	namespace 	
	GameStore
 
. 
Application 
.  
DTOS  $
.$ %
	Platforms% .
{ 
public 

class "
AddOrUpdatePlatformDTO '
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
}		 
}

 Ÿ

jC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\DTOS\Reviews\AddOrUpdateReviewDTO.cs
	namespace 	
	GameStore
 
. 
Application 
.  
DTOS  $
.$ %
Reviews% ,
{ 
public 

class  
AddOrUpdateReviewDTO %
{ 
public 
Guid 
? 
Id 
{ 
get 
; 
set "
;" #
}$ %
public		 
string		 
Review		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
[

 	
	MaxLength

	 
(

 
$num

 
)

 
]

 
[ 	
	MinLength	 
( 
$num 
) 
] 
public 
float 
Rating 
{ 
get !
;! "
set# &
;& '
}( )
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public 
Guid 
	ProductId 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} ä	
dC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Interfaces\ICompanyServices.cs
	namespace 	
	GameStore
 
. 
Application 
.  

Interfaces  *
{ 
public		 

	interface		 
ICompanyServices		 %
{

 
Task 
< 
IEnumerable 
< 
CompanyViewModel )
>) *
>* +
GetAllCompanies, ;
(; <
)< =
;= >
Task 
< 
CompanyViewModel 
> 
GetCompanyById -
(- .
Guid. 2
id3 5
)5 6
;6 7
void 
InsertCompany 
( !
AddOrUpdateCompanyDTO 0
company1 8
)8 9
;9 :
void 
UpdateCompany 
( !
AddOrUpdateCompanyDTO 0
company1 8
)8 9
;9 :
void 
DeleteCompany 
( 
Guid 
id  "
)" #
;# $
} 
} ç
aC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Interfaces\IGameServices.cs
	namespace 	
	GameStore
 
. 
Application 
.  

Interfaces  *
{ 
public		 

	interface		 
IGameServices		 "
{

 
Task 
< 
IEnumerable 
< 
GameListViewModel *
>* +
>+ ,
GetAllGames- 8
(8 9
)9 :
;: ;
Task 
< 
IEnumerable 
< 
dynamic  
>  !
>! "*
GetAllGamesWithDevelopersAsync# A
(A B
)B C
;C D
Task 
< 
GameViewModel 
> 
GetGameById '
(' (
Guid( ,
game- 1
)1 2
;2 3
Task 
< 
IEnumerable 
< 
GameListViewModel *
>* +
>+ ,
GetGamesByGenre- <
(< =
Guid= A
genreIdB I
)I J
;J K
Guid 

InsertGame 
( 
AddOrUpdateGameDTO *
game+ /
)/ 0
;0 1
void 

UpdateGame 
( 
AddOrUpdateGameDTO *
game+ /
)/ 0
;0 1
void 

DeleteGame 
( 
Guid 
id 
)  
;  !
Task 
UpdateThumbImage 
( 
Guid "
id# %
,% &
string' -
path. 2
)2 3
;3 4
Task 
< 
IEnumerable 
< 
GameListViewModel *
>* +
>+ ,
GetBestRatedGames- >
(> ?
)? @
;@ A
Task 
< 
IEnumerable 
< 
GameListViewModel *
>* +
>+ ,
GetBestSellerGames- ?
(? @
)@ A
;A B
} 
} Ô
bC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Interfaces\IGenreServices.cs
	namespace 	
	GameStore
 
. 
Application 
.  

Interfaces  *
{ 
public		 

	interface		 
IGenreServices		 #
{

 
Task 
< 
IEnumerable 
< 
GenreViewModel '
>' (
>( )
GetAllGenres* 6
(6 7
)7 8
;8 9
Task 
< 
GenreViewModel 
> 
GetGenreById )
() *
Guid* .
game/ 3
)3 4
;4 5
void 
InsertGenre 
( 
AddOrUpdateGenreDTO ,
game- 1
)1 2
;2 3
void 
UpdateGenre 
( 
AddOrUpdateGenreDTO ,
game- 1
)1 2
;2 3
void 
DeleteGenre 
( 
Guid 
id  
)  !
;! "
} 
} ê
bC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Interfaces\IOrderServices.cs
	namespace 	
	GameStore
 
. 
Application 
.  

Interfaces  *
{ 
public 

	interface 
IOrderServices #
{ 
CommandResult !
FinishCreditCardOrder +
(, -(
FinishCreditCardOrderCommand- I
orderJ O
,O P
GuidQ U
UserIdV \
)\ ]
;] ^
CommandResult		 
FinishPayPalOrder		 '
(		( )$
FinishPayPalOrderCommand		) A
order		B G
,		G H
Guid		I M
UserId		N T
)		T U
;		U V
}

 
} ú	
eC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Interfaces\IPlatformServices.cs
	namespace 	
	GameStore
 
. 
Application 
.  

Interfaces  *
{ 
public		 

	interface		 
IPlatformServices		 &
{

 
Task	 
< 
IEnumerable 
< 
PlatformViewModel +
>+ ,
>, -
GetAllPlatforms. =
(= >
)> ?
;? @
Task 
< 
PlatformViewModel 
> 
GetPlatformById  /
(/ 0
Guid0 4
platform5 =
)= >
;> ?
void 
InsertPlatform 
( "
AddOrUpdatePlatformDTO 2
platform3 ;
); <
;< =
void 
UpdatePlatform 
( "
AddOrUpdatePlatformDTO 2
platform3 ;
); <
;< =
void 
DeletePlatform 
( 
Guid  
id! #
)# $
;$ %
} 
} Å	
cC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Interfaces\IReviewServices.cs
	namespace 	
	GameStore
 
. 
Application 
.  

Interfaces  *
{ 
public 

	interface 
IReviewServices $
{% &
IEnumerable		 
<		 
ReviewListViewModel		 '
>		' ( 
GetReviewByProductId		) =
(		= >
Guid		> B
	productId		C L
)		L M
;		M N
IEnumerable

 
<

 
ReviewListViewModel

 '
>

' (
GetReviewByUserId

) :
(

: ;
Guid

; ?
userId

@ F
)

F G
;

G H
Guid 
Save 
(  
AddOrUpdateReviewDTO &
command' .
). /
;/ 0
void 
Update 
(  
AddOrUpdateReviewDTO (
command) 0
)0 1
;1 2
void 
Delete 
( 
Guid 
id 
) 
; 
} 
} ®
aC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Services\CompanyServices.cs
	namespace 	
	GameStore
 
. 
Application 
.  
Services  (
{ 
public 

class 
CompanyServices  
:! "
ICompanyServices# 3
{ 
private 
IUnitOfWork 
_unit !
;! "
private 
IMapper 
_mapper 
;  
public 
CompanyServices 
( 
IUnitOfWork *
unit+ /
,/ 0
IMapper1 8
mapper9 ?
)? @
{ 	
_unit 
= 
unit 
; 
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
CompanyViewModel& 6
>6 7
>7 8
GetAllCompanies9 H
(H I
)I J
{ 	
return 
_mapper 
. 
Map 
< 
IEnumerable *
<* +
CompanyViewModel+ ;
>; <
>< =
(= >
await> C
_unitD I
.I J
	CompaniesJ S
.S T
GetAllAsyncT _
(_ `
)` a
)a b
;b c
} 	
public 
async 
Task 
< 
CompanyViewModel *
>* +
GetCompanyById, :
(: ;
Guid; ?
id@ B
)B C
{ 	
return 
_mapper 
. 
Map 
< 
CompanyViewModel /
>/ 0
(0 1
await1 6
_unit7 <
.< =
	Companies= F
.F G
GetByIdAsyncG S
(S T
idT V
)V W
)W X
;X Y
} 	
public   
void   
InsertCompany   !
(  ! "!
AddOrUpdateCompanyDTO  " 7
company  8 ?
)  ? @
{!! 	
_unit"" 
."" 
	Companies"" 
."" 
Add"" 
(""  
_mapper""  '
.""' (
Map""( +
<""+ ,
Company"", 3
>""3 4
(""4 5
company""5 <
)""< =
)""= >
;""> ?
}## 	
public%% 
void%% 
UpdateCompany%% !
(%%" #!
AddOrUpdateCompanyDTO%%# 8
company%%9 @
)%%@ A
{&& 	
_unit'' 
.'' 
	Companies'' 
.'' 
Update'' "
(''" #
_mapper''# *
.''* +
Map''+ .
<''. /
Company''/ 6
>''6 7
(''7 8
company''8 ?
)''? @
)''@ A
;''A B
}(( 	
public** 
void** 
DeleteCompany** !
(**" #
Guid**# '
id**( *
)*** +
{++ 	
_unit,, 
.,, 
	Companies,, 
.,, 
Remove,, "
(,," #
id,,# %
),,% &
;,,& '
}-- 	
}.. 
}// ñ3
^C:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Services\GameServices.cs
	namespace 	
	GameStore
 
. 
Application 
.  
Services  (
{ 
public 

class 
GameServices 
: 
IGameServices  -
{ 
private 
IUnitOfWork 
_unit !
;! "
private 
IMapper 
_mapper 
;  
public 
GameServices 
( 
IUnitOfWork '
unit( ,
,, -
IMapper. 5
mapper6 <
)< =
{ 	
_unit 
= 
unit 
; 
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
dynamic& -
>- .
>. /*
GetAllGamesWithDevelopersAsync0 N
(N O
)O P
{ 	
return 
await 
_unit 
. 
Games $
.$ %*
GetAllGamesWithDevelopersAsync% C
(C D
)D E
;E F
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
GameListViewModel& 7
>7 8
>8 9
GetAllGames: E
(E F
)F G
{ 	
return 
_mapper 
. 
Map 
< 
IEnumerable *
<* +
GameListViewModel+ <
>< =
>= >
(> ?
await? D
_unitE J
.J K
GamesK P
.P Q
GetAllAsyncQ \
(\ ]
)] ^
)^ _
;_ `
}   	
public"" 
async"" 
Task"" 
<"" 
GameViewModel"" '
>""' (
GetGameById"") 4
(""4 5
Guid""5 9
gameId"": @
)""@ A
{## 	
return$$ 
_mapper$$ 
.$$ 
Map$$ 
<$$ 
GameViewModel$$ ,
>$$, -
($$- .
await$$. 3
_unit$$4 9
.$$9 :
Games$$: ?
.$$? @
GetByIdAsync$$@ L
($$L M
gameId$$M S
)$$S T
)$$T U
;$$U V
}%% 	
public'' 
async'' 
Task'' 
<'' 
IEnumerable'' %
<''% &
GameListViewModel''& 7
>''7 8
>''8 9
GetGamesByGenre'': I
(''I J
Guid''J N
genreId''O V
)''V W
{(( 	
return)) 
_mapper)) 
.)) 
Map)) 
<)) 
IEnumerable)) *
<))* +
GameListViewModel))+ <
>))< =
>))= >
())> ?
await))? D
_unit))E J
.))J K
Games))K P
.))P Q)
GetAllGamesFromThisGenreAsync))Q n
())n o
genreId))o v
)))v w
)))w x
;))x y
}** 	
public,, 
Guid,, 

InsertGame,, 
(,, 
AddOrUpdateGameDTO,, 1
gamevm,,2 8
),,8 9
{-- 	
return.. 
_unit.. 
... 
Games.. 
... 
Add.. "
(.." #
_mapper..# *
...* +
Map..+ .
<... /
Game../ 3
>..3 4
(..4 5
gamevm..5 ;
)..; <
)..< =
;..= >
}// 	
public00 
void00 

UpdateGame00 
(00 
AddOrUpdateGameDTO00 1
gamevm002 8
)008 9
{11 	
_unit22 
.22 
Games22 
.22 
Update22 
(22 
_mapper22 &
.22& '
Map22' *
<22* +
Game22+ /
>22/ 0
(220 1
gamevm221 7
)227 8
)228 9
;229 :
}33 	
public44 
void44 

DeleteGame44 
(44 
Guid44 #
id44$ &
)44& '
{55 	
_unit66 
.66 
Games66 
.66 
Remove66 
(66 
id66 !
)66! "
;66" #
}77 	
public99 
async99 
Task99 
<99 
IEnumerable99 %
<99% &
GameListViewModel99& 7
>997 8
>998 9
GetBestRatedGames99: K
(99K L
)99L M
{:: 	
return;; 
_mapper;; 
.;; 
Map;; 
<;; 
IEnumerable;; *
<;;* +
GameListViewModel;;+ <
>;;< =
>;;= >
(;;> ?
await;;? D
_unit;;E J
.;;J K
Games;;K P
.;;P Q"
GetBestRatedGamesAsync;;Q g
(;;g h
);;h i
);;i j
;;;j k
}<< 	
public>> 
async>> 
Task>> 
<>> 
IEnumerable>> %
<>>% &
GameListViewModel>>& 7
>>>7 8
>>>8 9
GetBestSellerGames>>: L
(>>L M
)>>M N
{?? 	
return@@ 
_mapper@@ 
.@@ 
Map@@ 
<@@ 
IEnumerable@@ *
<@@* +
GameListViewModel@@+ <
>@@< =
>@@= >
(@@> ?
await@@? D
_unit@@E J
.@@J K
Games@@K P
.@@P Q#
GetBestSellerGamesAsync@@Q h
(@@h i
)@@i j
)@@j k
;@@k l
}AA 	
publicCC 
asyncCC 
TaskCC 
UpdateThumbImageCC *
(CC* +
GuidCC+ /
idCC0 2
,CC2 3
stringCC4 :
pathCC; ?
)CC? @
{DD 	
varEE 
gameEE 
=EE 
awaitEE 
_unitEE "
.EE" #
GamesEE# (
.EE( )
GetByIdAsyncEE) 5
(EE5 6
idEE6 8
)EE8 9
;EE9 :
gameFF 
.FF  
ChangeThumbImagePathFF %
(FF% &
pathFF& *
)FF* +
;FF+ ,
_unitGG 
.GG 
GamesGG 
.GG 
UpdateGG 
(GG 
gameGG #
)GG# $
;GG$ %
}HH 	
}II 
}JJ ˇ
_C:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Services\GenreServices.cs
	namespace 	
	GameStore
 
. 
Application 
.  
Services  (
{ 
public 

class 
GenreServices 
:  
IGenreServices! /
{ 
private 
IUnitOfWork 
_unit !
;! "
private 
IMapper 
_mapper 
;  
public 
GenreServices 
( 
IUnitOfWork (
unit) -
,- .
IMapper/ 6
mapper7 =
)= >
{ 	
_unit 
= 
unit 
; 
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
GenreViewModel& 4
>4 5
>5 6
GetAllGenres7 C
(C D
)D E
{ 	
return 
_mapper 
. 
Map 
< 
IEnumerable *
<* +
GenreViewModel+ 9
>9 :
>: ;
(; <
await< A
_unitB G
.G H
GenresH N
.N O
GetAllAsyncO Z
(Z [
)[ \
)\ ]
;] ^
} 	
public 
async 
Task 
< 
GenreViewModel (
>( )
GetGenreById* 6
(6 7
Guid7 ;
genreId< C
)C D
{ 	
return 
_mapper 
. 
Map 
< 
GenreViewModel -
>- .
(. /
await/ 4
_unit5 :
.: ;
Games; @
.@ A
GetByIdAsyncA M
(M N
genreIdN U
)U V
)V W
;W X
}   	
public!! 
void!! 
InsertGenre!! 
(!!  
AddOrUpdateGenreDTO!!  3
genrevm!!4 ;
)!!; <
{"" 	
_unit## 
.## 
Genres## 
.## 
Add## 
(## 
_mapper## $
.##$ %
Map##% (
<##( )
Genre##) .
>##. /
(##/ 0
genrevm##0 7
)##7 8
)##8 9
;##9 :
}$$ 	
public%% 
void%% 
UpdateGenre%% 
(%%  
AddOrUpdateGenreDTO%%  3
genrevm%%4 ;
)%%; <
{&& 	
_unit'' 
.'' 
Genres'' 
.'' 
Update'' 
(''  
_mapper''  '
.''' (
Map''( +
<''+ ,
Genre'', 1
>''1 2
(''2 3
genrevm''3 :
)'': ;
)''; <
;''< =
}(( 	
public)) 
void)) 
DeleteGenre)) 
())  
Guid))  $
id))% '
)))' (
{** 	
_unit++ 
.++ 
Genres++ 
.++ 
Remove++ 
(++  
id++  "
)++" #
;++# $
},, 	
}-- 
}.. Ú*
_C:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Services\OrderServices.cs
	namespace

 	
	GameStore


 
.

 
Application

 
.

  
Services

  (
{ 
public 

class 
OrderServices 
:  

Notifiable! +
,+ ,
IOrderServices- ;
{ 
private 
IUnitOfWork 
_unit !
;! "
private 
IMapper 
_mapper 
;  
public 
OrderServices 
( 
IUnitOfWork (
unit) -
,- .
IMapper/ 6
mapper7 =
)= >
{ 	
_unit 
= 
unit 
; 
_mapper 
= 
mapper 
; 
} 	
public 
CommandResult !
FinishCreditCardOrder 2
(2 3(
FinishCreditCardOrderCommand3 O
commandP W
,W X
GuidY ]
UserId^ d
)d e
{ 	
var 
email 
= 
new 
Email !
(! "
command" )
.) *
Email* /
)/ 0
;0 1
var 
payment 
= 
new 
CreditCardPayment /
(/ 0
command 
. 
CardHolderName %
,% &
command 
. 

CardNumber !
,! "
command 
. 
PaidDate 
,  
command 
. 

ExpireDate !
,! "
command 
. 
Total 
, 
command   
.   
	TotalPaid    
,    !
command!! 
.!! 
Payer!! 
,!! 
email"" 
)"" 
;"" 
var$$ 
cart$$ 
=$$ 
new$$ 
ShoppingCart$$ '
($$' (
UserId$$( .
,$$/ 0
command$$0 7
.$$7 8
ListOfItems$$8 C
)$$C D
;$$D E
var&& 
order&& 
=&& 
new&& 
Order&& !
(&&! "
UserId&&" (
,&&( )
cart&&* .
,&&. /
payment&&0 7
)&&7 8
;&&8 9
order(( 
.(( 
AddNonconformity(( "
(((" #
payment((# *
,((* +
cart((, 0
)((0 1
;((1 2
if** 
(** 
order** 
.** 
	IsInvalid** 
)**  
return++ 
new++ 
CommandResult++ (
(++( )
false++) .
,++. /
$str++0 Q
)++Q R
;++R S
_unit-- 
.-- 
Orders-- 
.-- 
CreateOrder-- $
(--$ %
order--% *
)--* +
;--+ ,
return// 
new// 
CommandResult// $
(//$ %
true//% )
,//) *
$str//+ I
)//I J
;//J K
}00 	
public22 
CommandResult22 
FinishPayPalOrder22 .
(22. /$
FinishPayPalOrderCommand22/ G
command22H O
,22O P
Guid22Q U
UserId22V \
)22\ ]
{33 	
var44 
email44 
=44 
new44 
Email44 !
(44! "
command44" )
.44) *
Email44* /
)44/ 0
;440 1
var66 
payment66 
=66 
new66 
PayPalPayment66 +
(66+ ,
command77 
.77 
TransactionCode77 &
,77& '
command88 
.88 
PaidDate88 
,88  
command99 
.99 

ExpireDate99 !
,99! "
command:: 
.:: 
Total:: 
,:: 
command;; 
.;; 
	TotalPaid;;  
,;;  !
command<< 
.<< 
Payer<< 
,<< 
email== 
)== 
;== 
var?? 
cart?? 
=?? 
new?? 
ShoppingCart?? '
(??' (
UserId??( .
,??. /
command??/ 6
.??6 7
ListOfItems??7 B
)??B C
;??C D
varAA 
orderAA 
=AA 
newAA 
OrderAA !
(AA! "
UserIdAA" (
,AA( )
cartAA* .
,AA. /
paymentAA0 7
)AA7 8
;AA8 9
orderCC 
.CC 
AddNonconformityCC "
(CC" #
paymentCC# *
,CC* +
cartCC, 0
)CC0 1
;CC1 2
ifEE 
(EE 
orderEE 
.EE 
	IsInvalidEE 
)EE  
returnFF 
newFF 
CommandResultFF (
(FF( )
falseFF) .
,FF. /
$strFF0 Q
)FFQ R
;FFR S
_unitHH 
.HH 
OrdersHH 
.HH 
CreateOrderHH $
(HH$ %
orderHH% *
)HH* +
;HH+ ,
returnJJ 
newJJ 
CommandResultJJ $
(JJ$ %
trueJJ% )
,JJ) *
$strJJ+ I
)JJI J
;JJJ K
}KK 	
}LL 
}MM ∏
bC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Services\PlatformServices.cs
	namespace 	
	GameStore
 
. 
Application 
.  
Services  (
{ 
public 

class 
PlatformServices !
:! "
IPlatformServices# 4
{ 
private 
IUnitOfWork 
_unit !
;! "
private 
IMapper 
_mapper 
;  
public 
PlatformServices 
(  
IUnitOfWork  +
unit, 0
,0 1
IMapper2 9
mapper: @
)@ A
{ 	
_unit 
= 
unit 
; 
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
PlatformViewModel& 7
>7 8
>8 9
GetAllPlatforms: I
(I J
)J K
{ 	
return 
_mapper 
. 
Map 
< 
IEnumerable *
<* +
PlatformViewModel+ <
>< =
>= >
(> ?
await? D
_unitE J
.J K
	PlatformsK T
.T U
GetAllAsyncU `
(` a
)a b
)b c
;c d
} 	
public 
async 
Task 
< 
PlatformViewModel +
>+ ,
GetPlatformById- <
(< =
Guid= A
idB D
)D E
{ 	
return 
_mapper 
. 
Map 
< 
PlatformViewModel 0
>0 1
(1 2
await2 7
_unit8 =
.= >
Games> C
.C D
GetByIdAsyncD P
(P Q
idQ S
)S T
)T U
;U V
} 	
public   
void   
InsertPlatform   "
(  " #"
AddOrUpdatePlatformDTO  # 9
platform  : B
)  B C
{!! 	
_unit"" 
."" 
	Platforms"" 
."" 
Add"" 
(""  
_mapper""  '
.""' (
Map""( +
<""+ ,
Platform"", 4
>""4 5
(""5 6
platform""6 >
)""> ?
)""? @
;""@ A
}## 	
public$$ 
void$$ 
UpdatePlatform$$ "
($$" #"
AddOrUpdatePlatformDTO$$# 9
platform$$: B
)$$B C
{%% 	
_unit&& 
.&& 
	Platforms&& 
.&& 
Update&& "
(&&" #
_mapper&&# *
.&&* +
Map&&+ .
<&&. /
Platform&&/ 7
>&&7 8
(&&8 9
platform&&9 A
)&&A B
)&&B C
;&&C D
}'' 	
public(( 
void(( 
DeletePlatform(( "
(((" #
Guid((# '
id((( *
)((* +
{)) 	
_unit** 
.** 
	Platforms** 
.** 
Remove** "
(**" #
id**# %
)**% &
;**& '
}++ 	
},, 
}-- ø
`C:\projects\repos\GameStore\src\2 - Application\GameStore.Application\Services\ReviewServices.cs
	namespace 	
	GameStore
 
. 
Application 
.  
Services  (
{ 
public 

class 
ReviewServices 
:  !
IReviewServices" 1
{ 
private 
IUnitOfWork 
_unit !
;! "
private 
IMapper 
_mapper 
;  
public 
ReviewServices 
( 
IUnitOfWork 
unit 
, 
IMapper 
mapper 
) 
{ 	
_unit 
= 
unit 
; 
_mapper 
= 
mapper 
; 
} 	
public 
IEnumerable 
< 
ReviewListViewModel .
>. / 
GetReviewByProductId0 D
(D E
GuidE I
	productIdJ S
)S T
{U V
return 
_mapper 
. 
Map 
< 
IEnumerable *
<* +
ReviewListViewModel+ >
>> ?
>? @
(@ A
_unitA F
.F G
ReviewsG N
.N O 
GetReviewByProductIdO c
(c d
	productIdd m
)m n
)n o
;o p
} 	
public 
IEnumerable 
< 
ReviewListViewModel .
>. /
GetReviewByUserId0 A
(A B
GuidB F
userIdG M
)M N
{O P
return   
_mapper   
.   
Map   
<   
IEnumerable   *
<  * +
ReviewListViewModel  + >
>  > ?
>  ? @
(  @ A
_unit  A F
.  F G
Reviews  G N
.  N O
GetReviewByUserId  O `
(  ` a
userId  a g
)  g h
)  h i
;  i j
}!! 	
public## 
void## 
Delete## 
(## 
Guid## 
id##  "
)##" #
{$$ 	
_unit%% 
.%% 
Reviews%% 
.%% 
Remove%%  
(%%  !
id%%! #
)%%# $
;%%$ %
}&& 	
public(( 
Guid(( 
Save(( 
(((  
AddOrUpdateReviewDTO(( -
command((. 5
)((5 6
{)) 	
return** 
_unit** 
.** 
Reviews**  
.**  !
Add**! $
(**$ %
_mapper**% ,
.**, -
Map**- 0
<**0 1
Review**1 7
>**7 8
(**8 9
command**9 @
)**@ A
)**A B
;**B C
}++ 	
public-- 
void-- 
Update-- 
(--  
AddOrUpdateReviewDTO-- /
command--0 7
)--7 8
{.. 	
_unit// 
.// 
Reviews// 
.// 
Update//  
(//  !
_mapper//! (
.//( )
Map//) ,
<//, -
Review//- 3
>//3 4
(//4 5
command//5 <
)//< =
)//= >
;//> ?
}00 	
}11 
}22 ñ
dC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\ViewModels\CompanyViewModel.cs
	namespace 	
	GameStore
 
. 
Application 
.  

ViewModels  *
{		 
public

 

class

 
CompanyViewModel

 !
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
CompanyName 
Name 
{  !
get" %
;% &
set' *
;* +
}, -
public 
DateTime 
Founded 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
LogoPath 
{  
get! $
;$ %
set& )
;) *
}+ ,
private 
ICollection 
< 
GameDeveloper )
>) *
GameDevelopers+ 9
{: ;
get< ?
;? @
setA D
;D E
}F G
private 
ICollection 
< 
GamePublisher )
>) *
GamePublishers+ 9
{: ;
get< ?
;? @
setA D
;D E
}F G
public 
IEnumerable 
< 
dynamic "
>" #
DevelopedGames$ 2
{ 	
get 
{ 
return 
GameDevelopers %
.% &
Select& ,
(, -
e- .
=>/ 1
new2 5
{ 
Id 
= 
e 
. 
Game 
.  
Id  "
," #
Name 
= 
e 
. 
Game !
.! "
Name" &
} 
) 
; 
} 
} 	
public   
IEnumerable   
<   
dynamic   "
>  " #
PublishedGames  $ 2
{!! 	
get"" 
{## 
return$$ 
GamePublishers$$ %
.$$% &
Select$$& ,
($$, -
p$$- .
=>$$/ 1
new$$2 5
{%% 
Id&& 
=&& 
p&& 
.&& 
Game&& 
.&&  
Id&&  "
,&&" #
Name'' 
='' 
p'' 
.'' 
Game'' !
.''! "
Name''" &
}(( 
)(( 
;(( 
})) 
}** 	
}++ 
},, Õ
eC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\ViewModels\GameListViewModel.cs
	namespace

 	
	GameStore


 
.

 
Application

 
.

  

ViewModels

  *
{ 
public 

class 
GameListViewModel "
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
DateTime 
ReleaseDate #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
double 
? 

UsersScore !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
ShortDescription &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
ImageRelativePath '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string "
CoverImageRelativePath ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
} 
} —.
aC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\ViewModels\GameViewModel.cs
	namespace

 	
	GameStore


 
.

 
Application

 
.

  

ViewModels

  *
{ 
public 

class 
GameViewModel 
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
DateTime 
ReleaseDate #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
double 
	UserScore 
{  !
get" %
;% &
set' *
;* +
}, -
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
ShortDescription &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
ImageRelativePath '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string "
CoverImageRelativePath ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
private 
ICollection 
< 
GameDeveloper )
>) *
GameDevelopers+ 9
{: ;
get< ?
;? @
setA D
;D E
}F G
private 
ICollection 
< 
GamePlatform (
>( )
GamePlatforms* 7
{8 9
get: =
;= >
set? B
;B C
}D E
private 
ICollection 
< 
	GameGenre %
>% &

GameGenres' 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
private 
ICollection 
< 
GamePublisher )
>) *
GamePublishers+ 9
{: ;
get< ?
;? @
setA D
;D E
}F G
public 
IEnumerable 
< 
dynamic "
>" #

Developers$ .
{ 	
get 
{   
return!! 
GameDevelopers!! %
.!!% &
Select!!& ,
(!!, -
e!!- .
=>!!/ 1
new!!2 5
{"" 
Id## 
=## 
e## 
.## 
	Developer## $
.##$ %
Id##% '
,##' (
Name$$ 
=$$ 
e$$ 
.$$ 
	Developer$$ &
.$$& '
Name$$' +
,$$+ ,
Foundingdate%%  
=%%! "
e%%# $
.%%$ %
	Developer%%% .
.%%. /
Founded%%/ 6
,%%6 7
LogoPath&& 
=&& 
e&&  
.&&  !
	Developer&&! *
.&&* +
LogoPath&&+ 3
}'' 
)'' 
;'' 
}(( 
})) 	
public** 
IEnumerable** 
<** 
dynamic** "
>**" #
Genres**$ *
{++ 	
get,, 
{-- 
return.. 

GameGenres.. !
...! "
Select.." (
(..( )
e..) *
=>..+ -
new... 1
{// 
Id00 
=00 
e00 
.00 
Genre00  
.00  !
Id00! #
,00# $
Name11 
=11 
e11 
.11 
Genre11 "
.11" #
Name11# '
,11' (
Description22 
=22  !
e22" #
.22# $
Genre22$ )
.22) *
Description22* 5
}33 
)33 
;33 
}44 
}55 	
public66 
IEnumerable66 
<66 
dynamic66 "
>66" #

Publishers66$ .
{77 	
get88 
{99 
return:: 
GamePublishers:: %
.::% &
Select::& ,
(::, -
e::- .
=>::/ 1
new::2 5
{;; 
Id<< 
=<< 
e<< 
.<< 
	Publisher<< $
.<<$ %
Id<<% '
,<<' (
Name== 
=== 
e== 
.== 
	Publisher== &
.==& '
Name==' +
,==+ ,
Foundingdate>>  
=>>! "
e>># $
.>>$ %
	Publisher>>% .
.>>. /
Founded>>/ 6
,>>6 7
LogoPath?? 
=?? 
e??  
.??  !
	Publisher??! *
.??* +
LogoPath??+ 3
}@@ 
)@@ 
;@@ 
}AA 
}BB 	
publicCC 
IEnumerableCC 
<CC 
dynamicCC "
>CC" #
	PlatformsCC$ -
{DD 	
getEE 
{FF 
returnGG 
GamePlatformsGG $
.GG$ %
SelectGG% +
(GG+ ,
eGG, -
=>GG. 0
newGG1 4
{HH 
IdII 
=II 
eII 
.II 
PlatformII #
.II# $
IdII$ &
,II& '
NameJJ 
=JJ 
eJJ 
.JJ 
PlatformJJ %
.JJ% &
NameJJ& *
}KK 
)KK 
;KK 
}LL 
}MM 	
}NN 
}OO ë
bC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\ViewModels\GenreViewModel.cs
	namespace 	
	GameStore
 
. 
Application 
.  

ViewModels  *
{		 
public

 

class

 
GenreViewModel

 
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
private 
ICollection 
< 
	GameGenre %
>% &

GameGenres' 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
public 
IEnumerable 
< 
dynamic "
>" #
GamesOfThisGenre$ 4
{ 	
get 
{ 
return 

GameGenres !
.! "
Select" (
(( )
e) *
=>+ -
new. 1
{ 
Id 
= 
e 
. 
Game 
.  
Id  "
," #
Name 
= 
e 
. 
Game !
.! "
Name" &
,& '
} 
) 
; 
} 
} 	
} 
} Ñ
eC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\ViewModels\PlatformViewModel.cs
	namespace 	
	GameStore
 
. 
Application 
.  

ViewModels  *
{		 
public

 

class

 
PlatformViewModel

 "
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
private 
ICollection 
< 
GamePlatform (
>( )
GamePlatforms* 7
{8 9
get: =
;= >
set? B
;B C
}D E
public 
IEnumerable 
< 
dynamic "
>" #
GamesOfThisPlatform$ 7
{ 	
get 
{ 
return 
GamePlatforms $
.$ %
Select% +
(+ ,
e, -
=>. 0
new1 4
{ 
Id 
= 
e 
. 
Game 
.  
Id  "
," #
Name 
= 
e 
. 
Game !
.! "
Name" &
,& '
} 
) 
; 
} 
} 	
} 
} Ÿ
cC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\ViewModels\ResultViewModel.cs
	namespace 	
	GameStore
 
. 
Application 
.  

ViewModels  *
{ 
public 

class 
ResultViewModel  
{! "
public 
ResultViewModel 
( 
)  
{ 	
}		 	
public

 
ResultViewModel

 
(

 
int

 "

httpStatus

# -
,

- .
string

/ 5
message

6 =
)

= >
{ 	

HttpStatus 
= 

httpStatus #
;# $
Message 
= 
message 
; 
} 	
public 
ResultViewModel 
( 
Guid #
id$ &
,& '
int( +

httpStatus, 6
,6 7
string8 >
message? F
)F G
{ 	
Id 
= 
id 
; 

HttpStatus 
= 

httpStatus #
;# $
Message 
= 
message 
; 
} 	
public 
Guid 
? 
Id 
{ 
get 
; 
set "
;" #
}$ %
public 
int 

HttpStatus 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} ”
gC:\projects\repos\GameStore\src\2 - Application\GameStore.Application\ViewModels\ReviewListViewModel.cs
	namespace 	
	GameStore
 
. 
Application 
.  

ViewModels  *
{ 
public 

class 
ReviewListViewModel $
{ 
public		 
Guid		 
UserId		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public

 
Guid

 
	ProductId

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
double 
Rating 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Considerations $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} 