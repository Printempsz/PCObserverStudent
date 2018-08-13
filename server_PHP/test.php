<?php
namespace app;
// trait gg {
//     public static function mm() {
//         echo __TRAIT__;
//         echo PHP_EOL;
//         echo __FUNCTION__.PHP_EOL;
//         echo "ll";
//     }
// }
// trait ll {
//     public $ll = 0;
// }
// class ff {
//     use gg;
//     use ll;
//     private $dd = 8;
//     public static function fuck() {
//         echo __CLASS__ . PHP_EOL;
//         echo __TRAIT__;
//         echo "ttt";
//     }
// }


//     // $mm = new ff();
//     // echo $mm->fuck();
//     // echo gg::mm();

//     $class = new \ReflectionClass('ff');
//     $properties = $class->getProperties();
//     foreach($properties as $property) {
//         echo $property->getName()."\n";
//     }
$mode = [
    0 => 'blacklist_mode',
    1 => 'whitelist_mode'
];
if($_POST) {
    $file = fopen("1.txt","a+");
    fwrite($file,date('Y-m-d H:i:s')."\r\n".
        $_POST["hostname"]."\r\n".
        $_POST["ip"]."\r\n".
        $_POST["guid"]."\r\n".
        $mode[$_POST['mode']]."\r\n".
        $_POST["s"]."\r\n"
    );
    fclose($file);
}


