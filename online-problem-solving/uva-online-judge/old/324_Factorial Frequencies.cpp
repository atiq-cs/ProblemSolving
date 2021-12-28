/*******************************************************
*		Problem Name:	Factorial Frequencies
*		Problem ID:		324
*		Occassion:		Offline Solving
*
*		Algorithm:			Prime generation
*		Special Case:		Easy problem no special case
*		Judge Status:		Accepted
*		Author:				Atiqur Rahman
*******************************************************/
#include <math.h>
#include <string.h>
#include <stdio.h>

int digit[11];

class BigInt{
#define MAX(a,b)  ((a>b)?a:b)

		char *operand;
		bool sign;
public:
	BigInt(){

		operand=new char[2];
		strcpy(operand,"0");
			sign=0;
	}
	BigInt(int size){
	
		operand=new char[size+1];
		strcpy(operand,"0");
		sign=0;
		
	}
	BigInt(char ch[]){
	
			operand=new char[strlen(ch)+1];
			int i,j=0;
			sign=0;
			
			for(i=strlen(ch)-1;i>0;i--)
				operand[j++]=ch[i];
			if(ch[0]=='-')
				sign=1;
			else operand[j++]=ch[0];

			operand[j]=NULL;	
	}
	bool isGreater(char op1[],char op2[]){
	
	
		int len1=strlen(op1),len2=strlen(op2),i;
		if(len1<len2)  return false;
		
		if(len1==len2){

			for(i=len1-1;i>=0;i--)
				if(op1[i]<op2[i])
					return false;
				else if(op1[i]>op2[i]) return true;
		}
		return true;
	}
	bool isAbsZero(){

		int i;
		for(i=strlen(operand)-1;i>=0;i--)
			if(operand[i]!='0') return false;
		return true;
	}
	void absAdd(char op1[],char op2[],char res[]){
	
			int i,len1=strlen(op1),len2=strlen(op2),car=0,data1,data2,sum;
			for(i=0;i<len1||i<len2||car;i++){
			
				data1=data2=0;
				if(i<len1)	data1=op1[i]-48;
				if(i<len2)	data2=op2[i]-48;

				sum=data1+data2+car;
				res[i]=sum%10+48;
				car=sum/10;			
			}
			res[i]=NULL;
	}
	void absSub(char op1[],char op2[],char res[]){
	
			int i,len1=strlen(op1),len2=strlen(op2),car=0,data1,data2,sum;
			for(i=0;i<len1||i<len2||car;i++){
			
				data1=data2=0;
				if(i<len1)	data1=op1[i]-48;
				if(i<len2)	data2=op2[i]-48;
				
				sum=data1-data2-car;
				if(sum<0){
					sum+=10;
					car=1;
				}
				else car=0;						
				res[i]=sum+48;	
			}
			res[i]=NULL;
	}
	void absDiv(char op1[],char op2[],BigInt &res,BigInt &rem){
	
			int len1=strlen(op1),len2=strlen(op2),i,len3=len1,resDigit;
			res.operand[len1]=rem.operand[len3]=NULL;
			for(i=len1-1;i>=0;i--){
			
				rem.operand[i]=op1[i];
				
				resDigit=0;
				while(isGreater(&rem.operand[i],op2)){
				
					absSub(&rem.operand[i],op2,&rem.operand[i]);
					resDigit++;
					if(len3>1&&rem.operand[len3-1]=='0')					
						rem.operand[--len3]=NULL;
					
				}
				if(len3>1&&rem.operand[len3-1]=='0')					
						rem.operand[--len3]=NULL;
				res.operand[i]=resDigit+48;
			
			}
			
	
	}
	BigInt operator+(BigInt obj2){
	
		
			BigInt res(2+MAX(strlen(operand),strlen(obj2.operand)));
			if(sign==obj2.sign)
				res.sign=sign;
			if(sign^obj2.sign&&isGreater(operand,obj2.operand)){
			
				absSub(operand,obj2.operand,res.operand);
				res.sign=sign;
			}
			else if(sign^obj2.sign){
			
				absSub(obj2.operand,operand,res.operand);
				res.sign=obj2.sign;
			}
			else
				absAdd(operand,obj2.operand,res.operand);
			
		return res;
	}
	BigInt operator-(BigInt obj2){
	
		obj2.sign=(obj2.sign==true)?false:true;		 

		return (*this+obj2);
	}
	BigInt operator*(BigInt obj2){
	
			BigInt res(2+strlen(operand)+strlen(obj2.operand));
			if(sign^obj2.sign)
				res.sign=true;

			int len3=0,car,data1,data2,j,i,len2=strlen(obj2.operand),sum,len1=strlen(operand);
			for(i=0;i<len2;i++){
			
				car=0;
				data2=obj2.operand[i]-48;
				for(j=0;j<len1||car;j++){
				
					data1=(j<len1)?operand[j]-48:0;
					sum=data1*data2+car;
					sum+=(i+j>=len3)?0:res.operand[i+j]-48;
					car=sum/10;
					res.operand[i+j]=sum%10+48;					
				}
				len3=i+j;
			}
			res.operand[len3]=NULL;
			return res;
	}
	BigInt operator/(BigInt obj2){
	
			int l=strlen(operand);
			BigInt res(l+2),rem(l+2);

			if(sign^obj2.sign)
				res.sign=true;
			absDiv(operand,obj2.operand,res,rem);
		return res;
	
	}
	BigInt operator%(BigInt obj2){
	
			int l=strlen(operand);
			BigInt res(l+2),rem(l+2);

			absDiv(operand,obj2.operand,res,rem);
			if(sign&&!rem.isAbsZero()){
				obj2.sign=false;
				rem.sign=true;
				return rem+obj2;
			
			}			
		return rem;
	}
	//-------------------------relational operator-------------------
	bool operator>=(BigInt obj){
	
			BigInt temp;
			temp=*this-obj;
			return !temp.sign;	
	}
	bool operator>(BigInt obj){
	
			BigInt temp;
			temp=obj-*this;
			return temp.sign;	
	}
	bool operator<(BigInt obj){
	
			BigInt temp;
			temp=*this-obj;
			return temp.sign;	
	}
	bool operator<=(BigInt obj){
	
			BigInt temp;
			temp=obj-*this;
			return !temp.sign;	
	}
	bool operator==(BigInt obj){
	
			BigInt temp;
			temp=obj-*this;
			return temp.isAbsZero();	
	}
	//-------------------------------------------------------
	void show(){
		
			int i;
		
		/*	for(i=strlen(operand)-1;operand[i]=='0'&&i>0;i--)
				;
			if(sign&&(i||operand[i]!='0'))
					printf("-");
			for(;i>=0;i--)
				printf("%c",operand[i]);
			printf("\n");*/

			memset(digit, 0, 4 * 10);
			for (i=0; i<strlen(operand); i++) {
				digit[operand[i]-48]++;
			}
	}
};

int main() {
	freopen("324_in.txt", "r", stdin);

	int i,n;

	BigInt fact[400], tmp=BigInt("1"), aux = BigInt("2");

	fact[0] = BigInt("1");
	for (i=1; i<370; i++) {
		fact[i] = fact[i-1] * aux;
		aux = aux + tmp;
	}

	while (scanf("%d", &n) && n) {
		fact[n-1].show();
		printf("%d! --\n", n);
		for (i=0; i<5; i++)
			printf("   (%d)    %d", i, digit[i]);
		putchar('\n');

		for (i=5; i<10; i++)
			printf("   (%d)    %d", i, digit[i]);
		putchar('\n');
	}
	
	return 0;
}
