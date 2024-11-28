using tools;

namespace db;

public interface I_LevelDbNextReader:I_Iter<(str, str)>{

}

public interface I_LevelDbProcessor: I_process<(str, str)>, I_start{

}