namespace Lab4CSharp
{
    class ITriangle
{
    // Поля
    protected int a; // Сторона основи
    protected int b; // Бічна сторона
    protected int color; // Колір

    // Конструктор
    public ITriangle(int baseSide, int side, int col)
    {
        a = baseSide;
        b = side;
        color = col;
    }

    // Методи
    public void PrintDimensions()
    {
        Console.WriteLine($"Сторона основи: {a}, Бічна сторона: {b}");
    }

    public int Perimeter()
    {
        return 2 * b + a;
    }

    public double Area()
    {
        return 0.5 * a * Math.Sqrt(Math.Pow(b, 2) - Math.Pow(a / 2.0, 2));
    }

    public bool IsEquilateral()
    {
        return a == b;
    }

    // Властивості
    public int BaseSide
    {
        get { return a; }
        set { a = value; }
    }

    public int Side
    {
        get { return b; }
        set { b = value; }
    }

    public int Color
    {
        get { return color; }
    }

    // Індексатор
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return a;
                case 1:
                    return b;
                case 2:
                    return color;
                default:
                    throw new IndexOutOfRangeException("Недопустимий індекс");
            }
        }
        set
        {
            switch (index)
            {
                case 0:
                    a = value;
                    break;
                case 1:
                    b = value;
                    break;
                case 2:
                    color = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Недопустимий індекс");
            }
        }
    }

    // Перевантаження операції ++ і --
    public static ITriangle operator ++(ITriangle triangle)
    {
        triangle.a++;
        triangle.b++;
        return triangle;
    }

    public static ITriangle operator --(ITriangle triangle)
    {
        triangle.a--;
        triangle.b--;
        return triangle;
    }

    // Перевантаження операції *
    public static ITriangle operator *(ITriangle triangle, int scalar)
    {
        return new ITriangle(triangle.a * scalar, triangle.b * scalar, triangle.color);
    }

    // Перевантаження true і false
    public static bool operator true(ITriangle triangle)
    {
        return triangle.a > 0 && triangle.b > 0 && triangle.a < 2 * triangle.b;
    }

    public static bool operator false(ITriangle triangle)
    {
        return !(triangle.a > 0 && triangle.b > 0 && triangle.a < 2 * triangle.b);
    }

    // Перетворення типу ITriangle в string
    public static explicit operator string(ITriangle triangle)
    {
        return $"Сторона основи: {triangle.a}, Бічна сторона: {triangle.b}, Колір: {triangle.color}";
    }

    // Перетворення типу string в ITriangle
    public static explicit operator ITriangle(string str)
    {
        var parts = str.Split(',');
        int a = int.Parse(parts[0].Split(':')[1].Trim());
        int b = int.Parse(parts[1].Split(':')[1].Trim());
        int color = int.Parse(parts[2].Split(':')[1].Trim());
        return new ITriangle(a, b, color);
    }
}

///2

class VectorDecimal
{
    // Поля
    protected decimal[] ArrayDecimal;
    protected uint num;
    protected int codeError;
    protected static uint num_vec;

    // Конструктори
    public VectorDecimal()
    {
        ArrayDecimal = new decimal[1];
        ArrayDecimal[0] = 0;
        num = 1;
        codeError = 0;
        num_vec++;
    }

    public VectorDecimal(uint size)
    {
        ArrayDecimal = new decimal[size];
        for (int i = 0; i < size; i++)
        {
            ArrayDecimal[i] = 0;
        }
        num = size;
        codeError = 0;
        num_vec++;
    }

    public VectorDecimal(uint size, decimal initialValue)
    {
        ArrayDecimal = new decimal[size];
        for (int i = 0; i < size; i++)
        {
            ArrayDecimal[i] = initialValue;
        }
        num = size;
        codeError = 0;
        num_vec++;
    }

    // Деструктор
    ~VectorDecimal()
    {
        Console.WriteLine("VectorDecimal object is being destroyed");
    }

    // Методи
    public void InputElements()
    {
        Console.WriteLine("Введіть елементи вектора:");
        for (int i = 0; i < num; i++)
        {
            Console.Write($"Елемент {i}: ");
            ArrayDecimal[i] = Convert.ToDecimal(Console.ReadLine());
        }
    }

    public void PrintElements()
    {
        Console.WriteLine("Елементи вектора:");
        for (int i = 0; i < num; i++)
        {
            Console.WriteLine($"Елемент {i}: {ArrayDecimal[i]}");
        }
    }

    public void SetElements(decimal value)
    {
        for (int i = 0; i < num; i++)
        {
            ArrayDecimal[i] = value;
        }
    }

    public static uint GetNumVec()
    {
        return num_vec;
    }

    // Властивості
    public uint Size
    {
        get { return num; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public decimal this[int index]
    {
        get
        {
            if (index >= 0 && index < num)
            {
                return ArrayDecimal[index];
            }
            else
            {
                codeError = 1;
                return 0;
            }
        }
        set
        {
            if (index >= 0 && index < num)
            {
                ArrayDecimal[index] = value;
            }
            else
            {
                codeError = 1;
            }
        }
    }

    // Перевантаження унарних операцій ++ і --
    public static VectorDecimal operator ++(VectorDecimal vec)
    {
        for (int i = 0; i < vec.num; i++)
        {
            vec.ArrayDecimal[i]++;
        }
        return vec;
    }

    public static VectorDecimal operator --(VectorDecimal vec)
    {
        for (int i = 0; i < vec.num; i++)
        {
            vec.ArrayDecimal[i]--;
        }
        return vec;
    }

    // Перевантаження true і false
    public static bool operator true(VectorDecimal vec)
    {
        if (vec.num != 0)
        {
            foreach (var item in vec.ArrayDecimal)
            {
                if (item != 0) return true;
            }
        }
        return false;
    }

    public static bool operator false(VectorDecimal vec)
    {
        if (vec.num == 0) return true;
        foreach (var item in vec.ArrayDecimal)
        {
            if (item != 0) return false;
        }
        return true;
    }

    // Перевантаження унарної логічної операції !
    public static bool operator !(VectorDecimal vec)
    {
        return vec.num == 0 || vec.ArrayDecimal.All(x => x == 0);
    }

    // Перевантаження унарної побітової операції ~
    public static VectorDecimal operator ~(VectorDecimal vec)
    {
        for (int i = 0; i < vec.num; i++)
        {
            vec.ArrayDecimal[i] = Math.Floor(vec.ArrayDecimal[i]);
        }
        return vec;
    }

    // Перевантаження арифметичних бінарних операцій
    public static VectorDecimal operator +(VectorDecimal vec1, VectorDecimal vec2)
    {
        uint maxSize = Math.Max(vec1.num, vec2.num);
        VectorDecimal result = new VectorDecimal(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            if (i < vec1.num && i < vec2.num)
            {
                result.ArrayDecimal[i] = vec1.ArrayDecimal[i] + vec2.ArrayDecimal[i];
            }
            else if (i < vec1.num)
            {
                result.ArrayDecimal[i] = vec1.ArrayDecimal[i];
            }
            else if (i < vec2.num)
            {
                result.ArrayDecimal[i] = vec2.ArrayDecimal[i];
            }
        }
        return result;
    }

    public static VectorDecimal operator +(VectorDecimal vec, decimal scalar)
    {
        for (int i = 0; i < vec.num; i++)
        {
            vec.ArrayDecimal[i] += scalar;
        }
        return vec;
    }

    public static VectorDecimal operator -(VectorDecimal vec1, VectorDecimal vec2)
    {
        uint maxSize = Math.Max(vec1.num, vec2.num);
        VectorDecimal result = new VectorDecimal(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            if (i < vec1.num && i < vec2.num)
            {
                result.ArrayDecimal[i] = vec1.ArrayDecimal[i] - vec2.ArrayDecimal[i];
            }
            else if (i < vec1.num)
            {
                result.ArrayDecimal[i] = vec1.ArrayDecimal[i];
            }
            else if (i < vec2.num)
            {
                result.ArrayDecimal[i] = -vec2.ArrayDecimal[i];
            }
        }
        return result;
    }

    public static VectorDecimal operator -(VectorDecimal vec, decimal scalar)
    {
        for (int i = 0; i < vec.num; i++)
        {
            vec.ArrayDecimal[i] -= scalar;
        }
        return vec;
    }

    public static VectorDecimal operator *(VectorDecimal vec1, VectorDecimal vec2)
    {
        uint maxSize = Math.Max(vec1.num, vec2.num);
        VectorDecimal result = new VectorDecimal(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            if (i < vec1.num && i < vec2.num)
            {
                result.ArrayDecimal[i] = vec1.ArrayDecimal[i] * vec2.ArrayDecimal[i];
            }
            else if (i < vec1.num)
            {
                result.ArrayDecimal[i] = vec1.ArrayDecimal[i];
            }
            else if (i < vec2.num)
            {
                result.ArrayDecimal[i] = vec2.ArrayDecimal[i];
            }
        }
        return result;
    }

    public static VectorDecimal operator *(VectorDecimal vec, decimal scalar)
    {
        for (int i = 0; i < vec.num; i++)
        {
            vec.ArrayDecimal[i] *= scalar;
        }
        return vec;
    }

    public static VectorDecimal operator /(VectorDecimal vec1, VectorDecimal vec2)
    {
        uint maxSize = Math.Max(vec1.num, vec2.num);
        VectorDecimal result = new VectorDecimal(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            if (i < vec1.num && i < vec2.num)
            {
                result.ArrayDecimal[i] = vec1.ArrayDecimal[i] / vec2.ArrayDecimal[i];
            }
            else if (i < vec1.num)
            {
                result.ArrayDecimal[i] = vec1.ArrayDecimal[i];
            }
            else if (i < vec2.num)
            {
                result.ArrayDecimal[i] = vec2.ArrayDecimal[i];
            }
        }
        return result;
    }

    public static VectorDecimal operator /(VectorDecimal vec, decimal scalar)
    {
        for (int i = 0; i < vec.num; i++)
        {
            vec.ArrayDecimal[i] /= scalar;
        }
        return vec;
    }

    public static VectorDecimal operator %(VectorDecimal vec1, VectorDecimal vec2)
    {
        uint maxSize = Math.Max(vec1.num, vec2.num);
        VectorDecimal result = new VectorDecimal(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            if (i < vec1.num && i < vec2.num)
            {
                result.ArrayDecimal[i] = vec1.ArrayDecimal[i] % vec2.ArrayDecimal[i];
            }
            else if (i < vec1.num)
            {
                result.ArrayDecimal[i] = vec1.ArrayDecimal[i];
            }
            else if (i < vec2.num)
            {
                result.ArrayDecimal[i] = vec2.ArrayDecimal[i];
            }
        }
        return result;
    }

    public static VectorDecimal operator %(VectorDecimal vec, decimal scalar)
    {
        for (int i = 0; i < vec.num; i++)
        {
            vec.ArrayDecimal[i] %= scalar;
        }
        return vec;
    }

    // Перевантаження операторів рівності та нерівності
    public static bool operator ==(VectorDecimal vec1, VectorDecimal vec2)
    {
        if (vec1.num != vec2.num) return false;
        for (int i = 0; i < vec1.num; i++)
        {
            if (vec1.ArrayDecimal[i] != vec2.ArrayDecimal[i]) return false;
        }
        return true;
    }

    public static bool operator !=(VectorDecimal vec1, VectorDecimal vec2)
    {
        return !(vec1 == vec2);
    }

    // Перевантаження операторів порівняння
    public static bool operator >(VectorDecimal vec1, VectorDecimal vec2)
    {
        if (vec1.num != vec2.num) return false;
        for (int i = 0; i < vec1.num; i++)
        {
            if (vec1.ArrayDecimal[i] <= vec2.ArrayDecimal[i]) return false;
        }
        return true;
    }

    public static bool operator >=(VectorDecimal vec1, VectorDecimal vec2)
    {
        if (vec1.num != vec2.num) return false;
        for (int i = 0; i < vec1.num; i++)
        {
            if (vec1.ArrayDecimal[i] < vec2.ArrayDecimal[i]) return false;
        }
        return true;
    }

    public static bool operator <(VectorDecimal vec1, VectorDecimal vec2)
    {
        if (vec1.num != vec2.num) return false;
        for (int i = 0; i < vec1.num; i++)
        {
            if (vec1.ArrayDecimal[i] >= vec2.ArrayDecimal[i]) return false;
        }
        return true;
    }

    public static bool operator <=(VectorDecimal vec1, VectorDecimal vec2)
    {
        if (vec1.num != vec2.num) return false;
        for (int i = 0; i < vec1.num; i++)
        {
            if (vec1.ArrayDecimal[i] > vec2.ArrayDecimal[i]) return false;
        }
        return true;
    }
}

///3

class DecimalMatrix
{
    // Поля
    protected decimal[,] DCArray;
    protected uint n, m;
    protected int codeError;
    protected static int num_mf;

    // Конструктори
    public DecimalMatrix()
    {
        DCArray = new decimal[1, 1];
        DCArray[0, 0] = 0;
        n = 1;
        m = 1;
        codeError = 0;
        num_mf++;
    }

    public DecimalMatrix(uint rows, uint cols)
    {
        DCArray = new decimal[rows, cols];
        n = rows;
        m = cols;
        codeError = 0;
        num_mf++;
    }

    public DecimalMatrix(uint rows, uint cols, decimal initialValue)
    {
        DCArray = new decimal[rows, cols];
        n = rows;
        m = cols;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                DCArray[i, j] = initialValue;
            }
        }
        codeError = 0;
        num_mf++;
    }

    // Деструктор
    ~DecimalMatrix()
    {
        Console.WriteLine("DecimalMatrix object is being destroyed");
    }

    // Методи
    public void InputElements()
    {
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Елемент [{i}, {j}]: ");
                DCArray[i, j] = Convert.ToDecimal(Console.ReadLine());
            }
        }
    }

    public void PrintElements()
    {
        Console.WriteLine("Елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{DCArray[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    public void SetElements(decimal value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                DCArray[i, j] = value;
            }
        }
    }

    public static int GetNumMf()
    {
        return num_mf;
    }

    // Властивості
    public uint Rows
    {
        get { return n; }
    }

    public uint Cols
    {
        get { return m; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатори
    public decimal this[int i, int j]
    {
        get
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                return DCArray[i, j];
            }
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                DCArray[i, j] = value;
            }
            else
            {
                codeError = -1;
            }
        }
    }

    public decimal this[int k]
    {
        get
        {
            int i = k / (int)m;
            int j = k % (int)m;
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                return DCArray[i, j];
            }
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            int i = k / (int)m;
            int j = k % (int)m;
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                DCArray[i, j] = value;
            }
            else
            {
                codeError = -1;
            }
        }
    }

    // Перевантаження унарних операцій ++ і --
    public static DecimalMatrix operator ++(DecimalMatrix mat)
    {
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                mat.DCArray[i, j]++;
            }
        }
        return mat;
    }

    public static DecimalMatrix operator --(DecimalMatrix mat)
    {
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                mat.DCArray[i, j]--;
            }
        }
        return mat;
    }

    // Перевантаження операторів true і false
    public static bool operator true(DecimalMatrix mat)
    {
        if (mat.n != 0 && mat.m != 0)
        {
            foreach (var item in mat.DCArray)
            {
                if (item != 0) return true;
            }
        }
        return false;
    }

    public static bool operator false(DecimalMatrix mat)
    {
        if (mat.n == 0 || mat.m == 0) return true;
        foreach (var item in mat.DCArray)
        {
            if (item != 0) return false;
        }
        return true;
    }

    // Перевантаження унарної логічної операції !
    public static bool operator !(DecimalMatrix mat)
    {
        return mat.n == 0 || mat.m == 0;
    }

    // Перевантаження унарної побітової операції ~
    public static DecimalMatrix operator ~(DecimalMatrix mat)
    {
        DecimalMatrix result = new DecimalMatrix(mat.n, mat.m);
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                int intValue = (int)mat.DCArray[i, j];
                intValue = ~intValue;
                result.DCArray[i, j] = (decimal)intValue;
            }
        }
        return result;
    }

    // Перевантаження арифметичних бінарних операцій
    public static DecimalMatrix operator +(DecimalMatrix mat1, DecimalMatrix mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
        {
            return mat1;
        }
        DecimalMatrix result = new DecimalMatrix(mat1.n, mat1.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                result.DCArray[i, j] = mat1.DCArray[i, j] + mat2.DCArray[i, j];
            }
        }
        return result;
    }

    public static DecimalMatrix operator +(DecimalMatrix mat, decimal scalar)
    {
        DecimalMatrix result = new DecimalMatrix(mat.n, mat.m);
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                result.DCArray[i, j] = mat.DCArray[i, j] + scalar;
            }
        }
        return result;
    }

    public static DecimalMatrix operator -(DecimalMatrix mat1, DecimalMatrix mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
        {
            return mat1;
        }
        DecimalMatrix result = new DecimalMatrix(mat1.n, mat1.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                result.DCArray[i, j] = mat1.DCArray[i, j] - mat2.DCArray[i, j];
            }
        }
        return result;
    }

    public static DecimalMatrix operator -(DecimalMatrix mat, decimal scalar)
    {
        DecimalMatrix result = new DecimalMatrix(mat.n, mat.m);
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                result.DCArray[i, j] = mat.DCArray[i, j] - scalar;
            }
        }
        return result;
    }

    public static DecimalMatrix operator *(DecimalMatrix mat1, DecimalMatrix mat2)
    {
        if (mat1.m != mat2.n)
        {
            return mat1;
        }
        DecimalMatrix result = new DecimalMatrix(mat1.n, mat2.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat2.m; j++)
            {
                result.DCArray[i, j] = 0;
                for (int k = 0; k < mat1.m; k++)
                {
                    result.DCArray[i, j] += mat1.DCArray[i, k] * mat2.DCArray[k, j];
                }
            }
        }
        return result;
    }

    public static DecimalMatrix operator *(DecimalMatrix mat, decimal scalar)
    {
        DecimalMatrix result = new DecimalMatrix(mat.n, mat.m);
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                result.DCArray[i, j] = mat.DCArray[i, j] * scalar;
            }
        }
        return result;
    }

    public static DecimalMatrix operator /(DecimalMatrix mat, decimal scalar)
    {
        DecimalMatrix result = new DecimalMatrix(mat.n, mat.m);
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                result.DCArray[i, j] = mat.DCArray[i, j] / scalar;
            }
        }
        return result;
    }

    public static DecimalMatrix operator %(DecimalMatrix mat, uint scalar)
    {
        DecimalMatrix result = new DecimalMatrix(mat.n, mat.m);
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                result.DCArray[i, j] = mat.DCArray[i, j] % scalar;
            }
        }
        return result;
    }

    // Перевантаження операторів рівності та нерівності
    public static bool operator ==(DecimalMatrix mat1, DecimalMatrix mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
        {
            return false;
        }
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                if (mat1.DCArray[i, j] != mat2.DCArray[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator !=(DecimalMatrix mat1, DecimalMatrix mat2)
    {
        return !(mat1 == mat2);
    }

    // Перевантаження операторів порівняння
    public static bool operator >(DecimalMatrix mat1, DecimalMatrix mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
        {
            return false;
        }
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                if (mat1.DCArray[i, j] <= mat2.DCArray[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator >=(DecimalMatrix mat1, DecimalMatrix mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
        {
            return false;
        }
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                if (mat1.DCArray[i, j] < mat2.DCArray[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator <(DecimalMatrix mat1, DecimalMatrix mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
        {
            return false;
        }
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                if (mat1.DCArray[i, j] >= mat2.DCArray[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator <=(DecimalMatrix mat1, DecimalMatrix mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
        {
            return false;
        }
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                if (mat1.DCArray[i, j] > mat2.DCArray[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}

    class Program
{
    static void Main(string[] args)
    {
static void task1(){
    ITriangle triangle = new ITriangle(3, 4, 1);
        triangle.PrintDimensions();
        Console.WriteLine("Периметр: " + triangle.Perimeter());
        Console.WriteLine("Площа: " + triangle.Area());
        Console.WriteLine("Чи рівносторонній: " + triangle.IsEquilateral());

        Console.WriteLine("Індексатор:");
        Console.WriteLine($"a: {triangle[0]}, b: {triangle[1]}, колір: {triangle[2]}");

        Console.WriteLine("Перевантаження ++ і --:");
        triangle++;
        Console.WriteLine($"a: {triangle[0]}, b: {triangle[1]}");
        triangle--;
        Console.WriteLine($"a: {triangle[0]}, b: {triangle[1]}");

        Console.WriteLine("Перевантаження *:");
        triangle = triangle * 2;
        Console.WriteLine($"a: {triangle[0]}, b: {triangle[1]}");

        Console.WriteLine("Перевантаження true і false:");
        if (triangle)
        {
            Console.WriteLine("Трикутник існує");
        }
        else
        {
            Console.WriteLine("Трикутник не існує");
        }

        Console.WriteLine("Перетворення типів:");
        string triangleString = (string)triangle;
        Console.WriteLine(triangleString);
        ITriangle newTriangle = (ITriangle)triangleString;
        newTriangle.PrintDimensions();
}
static void task2(){
    VectorDecimal vector1 = new VectorDecimal(3, 2.5m);
        VectorDecimal vector2 = new VectorDecimal(3, 1.5m);

        Console.WriteLine("Vector 1:");
        vector1.PrintElements();

        Console.WriteLine("Vector 2:");
        vector2.PrintElements();

        VectorDecimal vector3 = vector1 + vector2;
        Console.WriteLine("Vector 1 + Vector 2:");
        vector3.PrintElements();

        vector3 = vector1 - vector2;
        Console.WriteLine("Vector 1 - Vector 2:");
        vector3.PrintElements();

        vector3 = vector1 * 2;
        Console.WriteLine("Vector 1 * 2:");
        vector3.PrintElements();

        vector3 = vector1 / 2;
        Console.WriteLine("Vector 1 / 2:");
        vector3.PrintElements();

        vector3 = vector1 % 2;
        Console.WriteLine("Vector 1 % 2:");
        vector3.PrintElements();

        Console.WriteLine("Vector 1 == Vector 2: " + (vector1 == vector2));
        Console.WriteLine("Vector 1 != Vector 2: " + (vector1 != vector2));
        Console.WriteLine("Vector 1 > Vector 2: " + (vector1 > vector2));
        Console.WriteLine("Vector 1 >= Vector 2: " + (vector1 >= vector2));
        Console.WriteLine("Vector 1 < Vector 2: " + (vector1 < vector2));
        Console.WriteLine("Vector 1 <= Vector 2: " + (vector1 <= vector2));

        Console.WriteLine("Number of vectors: " + VectorDecimal.GetNumVec());
}
static void task3(){
    DecimalMatrix mat1 = new DecimalMatrix(2, 2, 1.5m);
        DecimalMatrix mat2 = new DecimalMatrix(2, 2, 2.5m);

        Console.WriteLine("Матриця 1:");
        mat1.PrintElements();

        Console.WriteLine("Матриця 2:");
        mat2.PrintElements();

        DecimalMatrix mat3 = mat1 + mat2;
        Console.WriteLine("Матриця 1 + Матриця 2:");
        mat3.PrintElements();

        mat3 = mat1 - mat2;
        Console.WriteLine("Матриця 1 - Матриця 2:");
        mat3.PrintElements();

        mat3 = mat1 * 2;
        Console.WriteLine("Матриця 1 * 2:");
        mat3.PrintElements();

        mat3 = mat1 / 2;
        Console.WriteLine("Матриця 1 / 2:");
        mat3.PrintElements();

        mat3 = mat1 % 2;
        Console.WriteLine("Матриця 1 % 2:");
        mat3.PrintElements();

        Console.WriteLine("Матриця 1 == Матриця 2: " + (mat1 == mat2));
        Console.WriteLine("Матриця 1 != Матриця 2: " + (mat1 != mat2));
        Console.WriteLine("Матриця 1 > Матриця 2: " + (mat1 > mat2));
        Console.WriteLine("Матриця 1 >= Матриця 2: " + (mat1 >= mat2));
        Console.WriteLine("Матриця 1 < Матриця 2: " + (mat1 < mat2));
        Console.WriteLine("Матриця 1 <= Матриця 2: " + (mat1 <= mat2));

        Console.WriteLine("Кількість матриць: " + DecimalMatrix.GetNumMf());
}
static void task4(){}
            while(true){
                Console.WriteLine("  ****  Lab 4  ****  \n\n");
                Console.Write("Press 0 to exit\n");
                Console.Write("Which task would you like to review ? (1-3) : ");
                string? str = Console.ReadLine();
                if ( str == "0") break;
                if (str != null && short.TryParse(str, out short ans))
                {
                    switch (ans)
                {
                    case 1: { task1(); break; }
                    case 2: { task2(); break; }
                    case 3: { task3(); break; }
                    default: { Console.WriteLine("Put the correct number"); break; }
                }
                }
            }
    }
}
}