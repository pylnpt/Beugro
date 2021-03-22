<?php
namespace app\Http\Controllers;

use Illuminate\Http\Request;

class HomeController extends Controller{
    function index(){
        return view('home');
    }
        
}