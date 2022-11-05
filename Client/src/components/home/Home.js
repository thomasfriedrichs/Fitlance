import Slider from "./Slider";
import { useAuth } from "../../context/AuthContext";

const Home = () => {
  const { token, setIsFormVisible } = useAuth();

  return (
    <div className="flex flex-col mt-8 mb-40">
      <section className="">
        <h1 className="text-center font-bold m-12 mt-20 sm:text-6xl">
          Welcome!
        </h1>
        <p className="text-center m-12 sm:text-3xl">
          Fitlance is a hub for finding the best personal trainers in your area
        </p>
        {token ? <></> :
          <div>
            <p className="text-center m-8 sm:text-3xl">Get started by registering today</p>
            <div className={token ? "hidden" : "flex flex-row justify-center items-center p-4"}>
              <div>
                <button
                  onClick={setIsFormVisible}
                  className="py-2 px-2 w-60 h-20 text-xl md:text-3xl text-gray-500 rounded hover:bg-green hover:text-white transition duration-150"
                >
                  Sign up
                </button>
              </div>
            </div>
          </div>
        }
      </section>
      <div>
        <Slider/>
      </div>
    </div>
  );
};

export default Home;