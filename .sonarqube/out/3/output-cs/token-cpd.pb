ò
hC:\projects\repos\GameStore\src\4 - Infra\GameStore.Infra.CrossCutting.IoC\NativeInjectorBootStrapper.cs
	namespace		 	
	GameStore		
 
.		 
Infra		 
.		 
CrossCutting		 &
.		& '
IoC		' *
{

 
public 

class &
NativeInjectorBootStrapper +
{ 
public 
static 
void 
RegisterServices +
(+ ,
IServiceCollection, >
services? G
)G H
{ 	
services 
. 
AddTransient !
<! "
IGameServices" /
,/ 0
GameServices1 =
>= >
(> ?
)? @
;@ A
services 
. 
AddTransient !
<! "
ICompanyServices" 2
,2 3
CompanyServices4 C
>C D
(D E
)E F
;F G
services 
. 
AddTransient !
<! "
IGenreServices" 0
,0 1
GenreServices2 ?
>? @
(@ A
)A B
;B C
services 
. 
AddTransient !
<! "
IOrderServices" 0
,0 1
OrderServices2 ?
>? @
(@ A
)A B
;B C
services 
. 
AddTransient !
<! "
IPlatformServices" 3
,3 4
PlatformServices5 E
>E F
(F G
)G H
;H I
services 
. 
AddTransient !
<! "
IReviewServices" 1
,1 2
ReviewServices3 A
>A B
(B C
)C D
;D E
services 
. 
AddTransient !
<! "
IUnitOfWork" -
,- .

UnitOfWork/ 9
>9 :
(: ;
); <
;< =
services 
. 
AddSingleton !
(! "
Mapper" (
.( )
Configuration) 6
)6 7
;7 8
services 
. 
	AddScoped 
< 
IMapper &
>& '
(' (
sp( *
=>+ -
new. 1
Mapper2 8
(8 9
sp9 ;
.; <
GetRequiredService< N
<N O

AutoMapperO Y
.Y Z"
IConfigurationProviderZ p
>p q
(q r
)r s
,s t
spu w
.w x

GetService	x ‚
)
‚ ƒ
)
ƒ „
;
„ …
services 
. 
	AddScoped 
< 
RoleManager *
<* +
IdentityRole+ 7
>7 8
>8 9
(9 :
): ;
;; <
services 
. 
	AddScoped 
< 
UserManager *
<* +
IdentityUser+ 7
>7 8
>8 9
(9 :
): ;
;; <
} 	
} 
} 