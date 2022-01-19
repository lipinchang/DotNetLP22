import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
//this solution is not compltely correct, but it is my first attempt. more test cases need to be tested with
public class GetMax {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		List<String> list = new ArrayList<String>();
		list.add("1 97");
		list.add("2");
		list.add("1 20");
		list.add("2");
		list.add("1 26");
		list.add("1 20");
		list.add("2");
		list.add("3");
		list.add("1 91");
		list.add("3");
		getMax(list);
	}
	
	public static List<Integer> getMax(List<String> operations) {
	    // Write your code here
	        
	       List<Integer> list = new ArrayList<Integer>();
	       
	       
	      
	       String s = "";
	       
	       for(int i = 0; i<operations.size(); i++){
	           if(operations.get(i).charAt(0) == '1'){
	               //add
	               //chec 3 char and more
	               if(operations.get(i).charAt(2) != ' '){
	                   //has 2nd var
	                   for(int j=2; j<operations.get(2).length(); j++){
	                	   s += Character.toString(operations.get(i).charAt(j));
	                	   System.out.println(Character.toString(operations.get(i).charAt(j)));
	                	   
	                   }
	                   list.add(Integer.valueOf(s));
	                   s = "";
	                 
	               }
	              
	           }
	           if(operations.get(i).charAt(0) == '2') {
	        	   //delete
	        	   list.remove(list.get(list.size()-1));
	           }
	           if(operations.get(i).charAt(0) == '3') {
	        	   //print max
	        	   
	        	   System.out.println("max: "+ Collections.max(list));
	           }
	       }
	    
	        System.out.println(list);
	        return list;
	    }

}
